using Microsoft.EntityFrameworkCore;
using NLog;
using Castle.Windsor;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Resources;

namespace Balda
{
    /// <summary>
    /// Форма с игрой
    /// </summary>
    public partial class GameForm : Form
    {
        private string[,] _boardState = new string[5, 5];
        private int _boardSize = 5;
        private Guid _gameId;
        private Guid _currentPlayerTurn;
        private readonly Guid _localUserId;
        private Guid? _leftPlayerId;
        private Guid? _rightPlayerId;
        private List<UserEntity> _users;

        private DataGridViewCell? _lastClickedLetterCell = null;
        private (int row, int col) _lastClickedEmptyCell = (-1, -1);
        private List<(int row, int col)> _availableCells = new List<(int row, int col)>();
        private List<(int row, int col)> _pressedLetterCells = new List<(int row, int col)>();
        private List<string> _usedWords = new List<string>();
        private List<(int row, int col, char letter)> _newLetters = new List<(int row, int col, char letter)>();

        private Thread _pollingThread;

        private readonly IWordValidator _wordValidator;
        private readonly IWindsorContainer _container;

        /// <summary>
        /// Конструктор для создателя игры
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="creatorId"></param>
        /// <param name="localUserId"></param>
        public GameForm(Guid gameId, Guid creatorId, Guid localUserId)
        {
            var directoryName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            var neededDirectory = Directory.GetParent(directoryName).Parent.Parent.ToString();
            string dictionaryFilePath = Path.Combine(neededDirectory, "Sources", "dictionary.txt");

            _container = new WindsorContainer();
            _container.Install(new ValidatorsInstaller(dictionaryFilePath));
            _wordValidator = _container.Resolve<IWordValidator>();

            _gameId = gameId;
            _currentPlayerTurn = creatorId;
            _localUserId = localUserId;
            InitializeComponent();
            InitializeBoard();
            LoadGameState();
            UpdateButtonStates();
            CheckWhoseTurn();
            LoadPlayers();
            PollingMethod();
            UpdateUIStrings();
        }

        /// <summary>
        /// Конструктор для подключающегося игрока
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="localUserId"></param>
        public GameForm(Guid gameId, Guid localUserId)
        {
            var directoryName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            var neededDirectory = Directory.GetParent(directoryName).Parent.Parent.ToString();
            string dictionaryFilePath = Path.Combine(neededDirectory, "Sources", "dictionary.txt");


            _container = new WindsorContainer();
            _container.Install(new ValidatorsInstaller(dictionaryFilePath));
            _wordValidator = _container.Resolve<IWordValidator>();

            _gameId = gameId;
            _localUserId = localUserId;
            _currentPlayerTurn = _localUserId;
            InitializeComponent();
            InitializeBoard();
            LoadGameState();
            UpdateButtonStates();
            CheckWhoseTurn();
            LoadPlayers();
            PollingMethod();
            UpdateUIStrings();
        }

        private readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly LanguageManager _languageManager = new LanguageManager();

        private void UpdateUIStrings()
        {
            ResourceManager resourceManager = new ResourceManager("Balda.GameForm", typeof(GameForm).Assembly);
            this.Text = _languageManager.GetString("$this.Text", "Balda.GameForm");
            clearButton.Text = _languageManager.GetString("clearButton.Text", "Balda.GameForm");
            acceptButton.Text = _languageManager.GetString("acceptButton.Text", "Balda.GameForm");
            skipButton.Text = _languageManager.GetString("skipButton.Text", "Balda.GameForm");
            label6.Text = _languageManager.GetString("label6.Text", "Balda.GameForm");
            label1.Text = _languageManager.GetString("label1.Text", "Balda.GameForm");
        }
        private void CheckWhoseTurn()
        {
            using (var db = new AppDbContext())
            {
                var game = db.Games.Include(g => g.Users).FirstOrDefault(g => g.Id == _gameId);
                if (game != null)
                {
                    _currentPlayerTurn = game.CurrentPlayerTurn;
                }
            }
        }

        private void InitializeBoard()
        {
            GameField.ColumnCount = _boardSize;
            GameField.RowCount = _boardSize;

            for (int i = 0; i < _boardSize; i++)
            {
                GameField.Columns[i].Width = 60;
                GameField.Rows[i].Height = 60;
                GameField.Columns[i].HeaderText = "";
            }
            GameField.RowHeadersVisible = false;

            for (int row = 0; row < _boardSize; row++)
            {
                for (int col = 0; col < _boardSize; col++)
                {
                    _boardState[row, col] = " ";
                    GameField.Rows[row].Cells[col].Value = _boardState[row, col];
                    GameField.Rows[row].Cells[col].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            this.GameField.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(GameField_CellClick);
        }

        private void PollingMethod()
        {
            _pollingThread = new Thread(() =>
            {
                while (true)
                {
                    CheckGameState();
                    Thread.Sleep(1000);
                }
            });
            _pollingThread.Start();
        }

        private void LoadGameState()
        {

            using (var db = new AppDbContext())
            {
                var game = db.Games.Include(g => g.Users).FirstOrDefault(g => g.Id == _gameId);
                if (game != null)
                {
                    _boardState = ConvertStringTo2DArray(game.BoardState, _boardSize);
                    UpdateBoard();

                }
            }
        }

        private string[,] ConvertStringToArray(string boardStateString)
        {
            if (string.IsNullOrEmpty(boardStateString) || boardStateString.Length != 25)
            {
                return new string[5, 5];
            }

            string[,] board = new string[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    board[i, j] = boardStateString[i * 5 + j].ToString();
                }
            }
            return board;
        }



        private string[,] ConvertStringTo2DArray(string boardState, int boardSize)
        {
            string[,] boardArray = new string[boardSize, boardSize];

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    int index = row * boardSize + col;
                    boardArray[row, col] = boardState[index].ToString();
                }
            }
            return boardArray;
        }

        private void UpdateBoard()
        {
            for (int row = 0; row < _boardSize; row++)
            {
                for (int col = 0; col < _boardSize; col++)
                {
                    GameField.Rows[row].Cells[col].Value = _boardState[row, col];
                }
            }
        }

        private void GameField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_localUserId != _currentPlayerTurn)
            {
                MessageBox.Show(_languageManager.GetString("ItsNotYourTurnMessage", "Balda.Resources.MessageSources"));
                GameField.ClearSelection();
                return;
            }
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int row = e.RowIndex;
            int col = e.ColumnIndex;

            var clickedCell = GameField.Rows[row].Cells[col];

            if (clickedCell.Value.ToString() != " " && !_pressedLetterCells.Contains((row, col)))
            {
                HandleLetterCellClick(clickedCell, row, col);
            }
            else if (clickedCell.Value.ToString() == " " && _lastClickedEmptyCell == (-1, -1))
            {
                HandleEmptyCellClick(row, col);
            }
            UpdateButtonStates();
        }

        private void HandleLetterCellClick(DataGridViewCell clickedCell, int row, int col)
        {
            if (_lastClickedLetterCell == null)
            {
                _lastClickedLetterCell = clickedCell;
                _pressedLetterCells.Add((row, col));
                wordTextBox.Text += clickedCell.Value.ToString();
                _availableCells = GetAdjacentCells(row, col);
            }
            else
            {
                if (_availableCells.Contains((row, col)))
                {
                    _lastClickedLetterCell = clickedCell;
                    _pressedLetterCells.Add((row, col));
                    wordTextBox.Text += clickedCell.Value.ToString();

                    _availableCells = GetAdjacentCells(row, col);
                }
            }
            UpdateButtonStates();
        }

        private void HandleEmptyCellClick(int row, int col)
        {
            if (GetAdjacentCells(row, col).Count == 0)
            {
                return;
            }
            var alphabetForm = new AlphabetForm();
            if (alphabetForm.ShowDialog() == DialogResult.OK)
            {
                char selectedLetter = alphabetForm.SelectedLetter;
                _boardState[row, col] = selectedLetter.ToString();
                GameField.Rows[row].Cells[col].Value = selectedLetter.ToString();
                _newLetters.Add((row, col, selectedLetter));
                _lastClickedEmptyCell = (row, col);
                UpdateBoard();

                _newLetters.Add((row, col, selectedLetter));
            }
            UpdateButtonStates();
        }

        private void LoadPlayers()
        {
            using (var db = new AppDbContext())
            {
                var game = db.Games.Include(g => g.Users).FirstOrDefault(g => g.Id == _gameId);
                if (game != null && game.Users != null && game.Users.Count == 2)
                {

                    var player1 = game.Users.FirstOrDefault(p => p.Id == _localUserId);
                    var player2 = game.Users.FirstOrDefault(p => p.Id != _localUserId);

                    _leftPlayerId = player1?.Id;
                    _rightPlayerId = player2?.Id;

                }
                UpdatePlayerLabels();
            }
        }

        private void UpdatePlayerLabels()
        {
            using (var db = new AppDbContext())
            {
                if (_leftPlayerId.HasValue)
                {
                    var leftPlayer = db.Users.Find(_leftPlayerId.Value);
                    if (leftPlayer != null)
                    {
                        leftPlayerLabelName.Text = $"{leftPlayer.Name}";
                        leftPlayerLabelScore.Text = $"{leftPlayer.Score}";
                    }
                    else
                    {
                        leftPlayerLabelName.Text = "Left Player: N/A";
                        leftPlayerLabelScore.Text = "Score: N/A";
                    }
                }

                if (_rightPlayerId.HasValue)
                {
                    var rightPlayer = db.Users.Find(_rightPlayerId.Value);
                    if (rightPlayer != null)
                    {
                        rightPlayerLableName.Text = $"{rightPlayer.Name}";
                        rightPlayerLabelScore.Text = $"{rightPlayer.Score}";
                    }
                    else
                    {
                        rightPlayerLableName.Text = "Right Player: N/A";
                        rightPlayerLabelScore.Text = "Score: N/A";

                    }
                }
            }
        }

        private List<(int row, int col)> GetAdjacentCells(int row, int col)
        {
            List<(int row, int col)> adjacentCells = new List<(int row, int col)>();

            if (row > 0 && _boardState[row - 1, col] != " " && !_pressedLetterCells.Contains((row - 1, col)))
                adjacentCells.Add((row - 1, col));

            if (row < _boardSize - 1 && _boardState[row + 1, col] != " " && !_pressedLetterCells.Contains((row + 1, col)))
                adjacentCells.Add((row + 1, col));

            if (col > 0 && _boardState[row, col - 1] != " " && !_pressedLetterCells.Contains((row, col - 1)))
                adjacentCells.Add((row, col - 1));

            if (col < _boardSize - 1 && _boardState[row, col + 1] != " " && !_pressedLetterCells.Contains((row, col + 1)))
                adjacentCells.Add((row, col + 1));

            return adjacentCells;
        }

        private void UpdateButtonStates()
        {
            for (int row = 0; row < _boardSize; row++)
            {
                for (int col = 0; col < _boardSize; col++)
                {
                    GameField.Rows[row].Cells[col].ReadOnly = false;

                    if (_pressedLetterCells.Contains((row, col)))
                    {
                        GameField.Rows[row].Cells[col].ReadOnly = true;
                    }
                    else if (_boardState[row, col] == " " && _lastClickedEmptyCell != (-1, -1))
                    {
                        GameField.Rows[row].Cells[col].ReadOnly = true;
                    }
                    else if (_lastClickedLetterCell != null && _boardState[row, col] != " ")
                    {
                        if (!_availableCells.Contains((row, col)))
                        {
                            GameField.Rows[row].Cells[col].ReadOnly = true;
                        }
                    }
                    else
                    {
                        GameField.Rows[row].Cells[col].ReadOnly = false;
                    }
                }
            }
        }

        private void UpdateGameState()
        {
            string[,] boardStateCopy = (string[,])_boardState.Clone();

            foreach (var (row, col, letter) in _newLetters)
            {
                boardStateCopy[row, col] = letter.ToString();
            }

            _boardState = boardStateCopy;


            using (var db = new AppDbContext())
            {
                var game = db.Games.Include(g => g.Users).FirstOrDefault(g => g.Id == _gameId);
                if (game != null)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            sb.Append(_boardState[i, j]);
                        }
                    }
                    game.BoardState = sb.ToString();
                    db.SaveChanges();
                }
            }
            _newLetters.Clear();

            LoadGameState();
        }

        private void UpdatePlayerScore(int score)
        {
            using (var db = new AppDbContext())
            {
                var game = db.Games.Include(g => g.Users).FirstOrDefault(g => g.Id == _gameId);
                if (game != null)
                {
                    var _game = game;
                    var currentPlayer = game.Users.FirstOrDefault(u => u.Id == _currentPlayerTurn);
                    currentPlayer.Score += score;
                    db.Update(currentPlayer);
                    UpdatePlayerLabels();
                    db.SaveChanges();
                    Logger.Info($"Игрок {_currentPlayerTurn} получил очки, нынешнее кол-во: {currentPlayer.Score}");
                }
            }
        }


        private void SwitchTurn()
        {
            using (var db = new AppDbContext())
            {
                var game = db.Games.Include(g => g.Users).FirstOrDefault(g => g.Id == _gameId);
                if (game != null)
                {
                    if (game.Users == null || game.Users.Count == 0)
                    {
                        Logger.Warn("No players found in the game.");
                        return;
                    }

                    Guid nextPlayerId = game.Users.First(p => p.Id != _localUserId).Id;
                    game.CurrentPlayerTurn = nextPlayerId;

                    db.SaveChanges();
                    CheckWhoseTurn();
                }
            }
        }

        private int GetPlayerScore(Guid? playerId)
        {
            if (!playerId.HasValue)
            {
                return 0;
            }

            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == playerId.Value);
                return user?.Score ?? 0;
            }
        }

        private void CheckGameState()
        {
            using (var db = new AppDbContext())
            {
                var game = db.Games.Include(g => g.Users).FirstOrDefault(g => g.Id == _gameId);

                if (game != null)
                {
                    bool hasChanges = false;

                    string[,] gameBoardState = ConvertStringToArray(game.BoardState);

                    if (game.CurrentPlayerTurn != _currentPlayerTurn)
                    {
                        _currentPlayerTurn = game.CurrentPlayerTurn;
                        hasChanges = true;
                    }

                    int leftPlayerScore = game.Users.FirstOrDefault(p => p.Id == _leftPlayerId)?.Score ?? 0;
                    if (leftPlayerScore != GetPlayerScore(_leftPlayerId))
                    {
                        hasChanges = true;
                    }
                    int rightPlayerScore = game.Users.FirstOrDefault(p => p.Id == _rightPlayerId)?.Score ?? 0;
                    if (rightPlayerScore != GetPlayerScore(_rightPlayerId))
                    {
                        hasChanges = true;
                    }

                    if (hasChanges)
                    {
                        UpdatePlayerLabels();
                        LoadGameState();
                        UpdateButtonStates();
                    }
                }
            }
        }
        private void ResetState()
        {
            wordTextBox.Clear();
            _lastClickedLetterCell = null;
            _lastClickedEmptyCell = (-1, -1);
            _availableCells.Clear();
            _pressedLetterCells.Clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (_localUserId != _currentPlayerTurn)
            {
                MessageBox.Show(_languageManager.GetString("ItsNotYourTurnMessage", "Balda.Resources.MessageSources"));
                return;
            }
            string word = wordTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show(_languageManager.GetString("EnterTheWordMessage", "Balda.Resources.MessageSources"));
                return;
            }

            if (!_wordValidator.IsValidWord(word))
            {
                MessageBox.Show(_languageManager.GetString("WordDoesntExistMessage", "Balda.Resources.MessageSources"));
                clearField();
                ResetState();
                return;
            }

            bool isWordHasNewLetter = false;
            foreach (var (row, col, letter) in _newLetters)
            {

                if (_boardState[row, col] != null)
                {
                    char newLetter = Convert.ToChar(_boardState[row, col].ToLower());
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == newLetter)
                        {
                            isWordHasNewLetter = true;
                            break;
                        }
                    }
                }
                if (isWordHasNewLetter)
                {
                    break;
                }
            }

            if (!isWordHasNewLetter)
            {
                MessageBox.Show(_languageManager.GetString("MustContainMessage", "Balda.Resources.MessageSources"));
                ResetState();
                return;
            }

            if (_usedWords.Contains(word))
            {
                MessageBox.Show(_languageManager.GetString("WasUsedWordMessage", "Balda.Resources.MessageSources"));
                clearField();
                ResetState();
                return;
            }

            _usedWords.Add(word);
            Logger.Info($"Слово '{word}' добавленно список использованных слов");

            int score = word.Length;

            if (IsBoardFull())
            {
                EndGame();
                return;
            }

            UpdatePlayerScore(score);
            UpdatePlayerLabels();
            UpdateGameState();
            ResetState();
            LoadGameState();
            SwitchTurn();
        }

        private void clearField()
        {
            if (_lastClickedEmptyCell.row != -1 && _lastClickedEmptyCell.col != -1)
            {
                (int row, int col) = _lastClickedEmptyCell;

                _boardState[row, col] = " ";

                GameField.Rows[row].Cells[col].Value = " ";

                _newLetters.RemoveAll(item => item.row == row && item.col == col);

                _lastClickedEmptyCell = (-1, -1);

                UpdateBoard();
                UpdateButtonStates();
            }
        }

        private bool IsBoardFull()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (_boardState[i, j] == " ")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void EndGame()
        {
            Guid winnerId = (Guid)_leftPlayerId;
            if (GetPlayerScore(_rightPlayerId) > GetPlayerScore(_leftPlayerId))
            {
                winnerId = (Guid)_rightPlayerId;
            }

            string winnerName = string.Empty;
            int winnerScore = 0;
            using (var db = new AppDbContext())
            {
                var winner = db.Users.Find(winnerId);
                winnerName = winner.Name;
                winnerScore = winner.Score;
                var game = db.Games.Find(_gameId);
                db.Games.Remove(game);
                var leftPlayer = db.Users.Find(_leftPlayerId);
                leftPlayer.Score = 0;
                var rightPlayer = db.Users.Find(_rightPlayerId);
                rightPlayer.Score = 0;
                db.SaveChanges();
                UpdatePlayerLabels();
            }

            MessageBox.Show($"{_languageManager.GetString("GameEndFirstPartMessage", "Balda.Resources.MessageSources")}: {winnerName} ({winnerScore} {_languageManager.GetString("GameEndSecondPartMessage", "Balda.Resources.MessageSources")}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearField();
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            clearField();
            SwitchTurn();
        }
    }
}
