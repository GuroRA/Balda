using System.Windows.Forms;

namespace Balda
{
    public partial class GameForm : Form
    {
        private string[,] _boardState = new string[5, 5];
        private int _boardSize = 5;
        public GameForm()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            GameField.ColumnCount = _boardSize;
            GameField.RowCount = _boardSize;

            for (int i = 0; i < _boardSize; i++)
            {
                GameField.Columns[i].Width = 70;
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
