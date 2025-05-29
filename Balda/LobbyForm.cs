using Microsoft.EntityFrameworkCore;
using NLog;
using System.Text;

namespace Balda
{
    public partial class LobbyForm : Form
    {
        private Guid _userId;
        private Guid _gameId;
        private Thread _pollingThread;
        public LobbyForm(Guid userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private void CreateGame_Click(object sender, EventArgs e)
        {
            CreateNewGame(_userId, 2);
        }

        private void CreateNewGame(Guid creatorUserId, int numberOfPlayers)
        {
            string initialWord = GetRandomFiveLetterWord();

            using (var db = new AppDbContext())
            {
                Logger.Info("Начало генераии игры");
                string boardState = GenerateInitialBoardState(initialWord);
                var creatorUser = db.Users.FirstOrDefault(u => u.Id == creatorUserId);
                if (creatorUser == null)
                {
                    MessageBox.Show("Пользователь не найден.");
                    return;
                }

                var newGame = new Game
                {
                    BoardState = boardState,
                    IsActive = true,
                    CurrentPlayerTurn = creatorUserId,
                    Users = new List<UserEntity> { creatorUser },
                    InitialWord = initialWord
                };
                Logger.Info("Добавление игры в бд");
                db.Games.Add(newGame);
                db.SaveChanges();

                _gameId = newGame.Id;
                Clipboard.SetText(_gameId.ToString());
                MessageBox.Show($"Id вашей игры: {newGame.Id} скопирован в буфер обмена");
                WaitForSecondPlayer(newGame.Id, newGame.CurrentPlayerTurn);
            }
        }

        private void JoinGame(Guid gameId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var game = db.Games.Include(g => g.Users).FirstOrDefault(g => g.Id == gameId);
                    if (game == null)
                    {
                        MessageBox.Show("Игра не найдена.");
                        return;
                    }

                    if (game.Users.Any(p => p.Id == _userId))
                    {
                        MessageBox.Show("Вы уже в этой игре.");
                        return;
                    }

                    if (game.Users.Count >= 2)
                    {
                        MessageBox.Show("В игре уже два игрока.");
                        return;
                    }

                    var user = db.Users.FirstOrDefault(u => u.Id == _userId);
                    if (user == null)
                    {
                        MessageBox.Show("Пользователь не найден.");
                        return;
                    }

                    game.Users.Add(user);
                    db.SaveChanges();
                    Logger.Info($"Пользователь {_userId} присоединился к игре {gameId}");

                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Не удалось подключиться к игре {gameId}");
                MessageBox.Show($"Не удалось подключиться к игре: {ex.Message}");
            }
        }

        private void WaitForSecondPlayer(Guid gameId, Guid creatorId)
        {
            _pollingThread = new Thread(() =>
            {
                while (true)
                {
                    using (var db = new AppDbContext())
                    {
                        var game = db.Games.Include(g => g.Users).FirstOrDefault(g => g.Id == gameId);
                        if (game != null && game.Users.Count == 2)
                        {
                            Logger.Info("Второй игрок подключился. Запуск игры...");
                            Invoke(new Action(() => {
                                OpenGameForm(gameId, creatorId, _userId);
                            }));
                            return;
                        }
                    }
                    Thread.Sleep(500);
                }
            });
            _pollingThread.Start();
        }

        private void OpenGameForm(Guid gameId, Guid creatorId, Guid userId)
        {

            var gameForm = new GameForm(gameId, creatorId, userId);
            gameForm.Show();
            this.Hide();
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

        private void rulesButton_Click(object sender, EventArgs e)
        {
            Logger.Info("Пользователь открыл правила с игрой");
            var RulesWindow = new RulesWindow();
            RulesWindow.Show();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            using (var inputForm = new ImputGameIdForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    Guid gameId = inputForm.GameId;
                    JoinGame(gameId);
                }
            }
        }
    }
}
