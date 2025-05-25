namespace Balda
{
    public partial class GameForm : Form
    {
        private string[,] _boardState = new string[5, 5];
        private int _boardSize = 5;
        private Guid _gameId;
        private Guid _creatorId;
        private DataGridViewCell _lastClickedLetterCell = null;
        private (int row, int col) _lastClickedEmptyCell = (-1, -1);
        private List<(int row, int col)> _availableCells = new List<(int row, int col)>();
        private List<(int row, int col)> _pressedLetterCells = new List<(int row, int col)>();
        public GameForm(Guid gameId, Guid creatorId)
        {
            _gameId = gameId;
            _creatorId = creatorId;
            InitializeComponent();
            InitializeBoard();
            LoadGameState();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
