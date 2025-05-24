namespace Balda
{
    public partial class GameForm : Form
    {
        private string[,] _boardState = new string[5, 5];
        private int _boardSize = 5;
        private Guid _gameId;
        private Guid _creatorId;
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
                    _boardState[row, col] = "F";
                    GameField.Rows[row].Cells[col].Value = _boardState[row, col];
                    GameField.Rows[row].Cells[col].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
