using NLog;
using System.Windows.Forms;

namespace Balda
{
    public partial class GameForm : Form
    {
        private string[,] _boardState = new string[5, 5];
        private int _boardSize = 5;
        private Guid _gameId;
        private Guid _currentPlayerTurn;
        private DataGridViewCell _lastClickedLetterCell = null;
        private (int row, int col) _lastClickedEmptyCell = (-1, -1);
        private List<(int row, int col)> _availableCells = new List<(int row, int col)>();
        private List<(int row, int col)> _pressedLetterCells = new List<(int row, int col)>();
        private readonly Guid _localUserId;
        private List<string> _usedWords = new List<string>();
        private readonly IWordValidator _wordValidator;

        public GameForm(Guid gameId, Guid creatorId, Guid localUserId)
        {
            var directoryName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            var neededDirectory = Directory.GetParent(directoryName).Parent.Parent.ToString();
            string dictionaryFilePath = Path.Combine(neededDirectory, "Sources", "dictionary.txt");
            _wordValidator = new DictionaryWordValidator(dictionaryFilePath);

            _gameId = gameId;
            _currentPlayerTurn = creatorId;
            InitializeComponent();
            InitializeBoard();
            LoadGameState();
            _localUserId = localUserId;
        }

        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private void CheckWhoseTurn()
        {
            using (var db = new AppDbContext())
            {
                var game = db.Games.FirstOrDefault(g => g.Id == _gameId);
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

        private void LoadGameState()
        {

            CheckWhoseTurn();
            using (var db = new AppDbContext())
            {
                var game = db.Games.Find(_gameId);
                if (game != null)
                {
                    _boardState = ConvertStringTo2DArray(game.BoardState, _boardSize);
                    UpdateBoard();

                }
            }
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
                MessageBox.Show("Сейчас не ваш ход!");
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
                _lastClickedEmptyCell = (row, col);
                UpdateBoard();
            }
            UpdateButtonStates();
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
        private void UpdatePlayerScore(int score)
        {
            using (var db = new AppDbContext())
            {
                var game = db.Games.Find(_gameId);
                if (game != null)
                {
                    var currentPlayer = game.Users.FirstOrDefault(u => u.Id == _currentPlayerTurn);
                    if (currentPlayer != null)
                    {
                        currentPlayer.Score += score;
                        db.SaveChanges();
                        Logger.Info($"Игрок {_currentPlayerTurn} получил очки, нынешнее кол-во: {currentPlayer.Score}");
                    }
                }
            }
        }


        private void SwitchTurn()
        {
            using (var db = new AppDbContext())
            {
                var game = db.Games.Find(_gameId);
                if (game != null)
                {
                    if (game.Users == null || game.Users.Count == 0)
                    {
                        Logger.Warn("No players found in the game.");
                        return;
                    }

                    Guid nextPlayerId = game.Users.FirstOrDefault(p => p.Id != _localUserId)?.Id ?? _localUserId;
                    game.CurrentPlayerTurn = nextPlayerId;

                    db.SaveChanges();
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
                MessageBox.Show("Сейчас не ваш ход!");
                return; // Прерываем обработку, если не наш ход
            }
            string word = wordTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Введите слово.");
                return;
            }

            if (!_wordValidator.IsValidWord(word))
            {
                MessageBox.Show("Такого слова не существует.");
                ResetState();
                UpdateButtonStates();
                return;
            }

            _usedWords.Add(word);
            Logger.Info($"Слово '{word}' добавленно список использованных слов");

            int score = word.Length;

            UpdatePlayerScore(score);
            SwitchTurn();
            LoadGameState();
        }
    }
}
