using System.Text;

namespace Balda
{
    public partial class LobbyForm : Form
    {
        private Guid _userId;
        public LobbyForm(Guid userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private void CreateGame_Click(object sender, EventArgs e)
        {
            CreateNewGame(_userId, 2);
        }

        private void CreateNewGame(Guid creatorUserId, int numberOfPlayers)
        {
            string initialWord = GetRandomFiveLetterWord();

            using (var db = new AppDbContext())
            {
                string boardState = GenerateInitialBoardState(initialWord);

                var newGame = new Game
                {
                    BoardState = boardState,
                    IsActive = true,
                    CurrentPlayerTurn = creatorUserId,
                    InitialWord = initialWord
                };

                db.Games.Add(newGame);
                db.SaveChanges();

                var gameForm = new GameForm(newGame.Id, creatorUserId);
                gameForm.Show();
                this.Hide();
            }
        }

        private string GetRandomFiveLetterWord()
        {
            string[] fiveLetterWords = { "БАЛДА", "СЛОВО", "СИРОП", "ЛОДКА", "РЕБРО" };
            Random random = new Random();
            int index = random.Next(fiveLetterWords.Length);
            return fiveLetterWords[index];
        }

        private string GenerateInitialBoardState(string initialWord)
        {
            StringBuilder sb = new StringBuilder(new string(' ', 25));
            for (int i = 0; i < 5; i++)
            {
                sb[10 + i] = initialWord[i]; 
            }
            return sb.ToString();
        }
    }
}
