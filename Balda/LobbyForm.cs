using Microsoft.EntityFrameworkCore;
using NLog;
using System.Resources;
using System.Text;

namespace Balda
{
    /// <summary>
    /// Форма лобби
    /// </summary>
    public partial class LobbyForm : Form
    {
        private Guid _userId;
        private Guid _gameId;
        private Thread _pollingThread;
        /// <summary>
        /// Конструктор инициализирующий форму
        /// </summary>
        /// <param name="userId"></param>
        public LobbyForm(Guid userId)
        {
            _userId = userId;
            InitializeComponent();
            UpdateUIStrings();
        }

        private readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly LanguageManager _languageManager = new LanguageManager();

        private void UpdateUIStrings()
        {
            ResourceManager resourceManager = new ResourceManager("Balda.LobbyForm", typeof(LobbyForm).Assembly);
            this.Text = _languageManager.GetString("$this.Text", "Balda.LobbyForm");
            CreateGame.Text = _languageManager.GetString("CreateGame.Text", "Balda.LobbyForm");
            ConnectButton.Text = _languageManager.GetString("ConnectButton.Text", "Balda.LobbyForm");
            rulesButton.Text = _languageManager.GetString("rulesButton.Text", "Balda.LobbyForm");
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
                Logger.Info("Начало генераии игры");
                string boardState = GenerateInitialBoardState(initialWord);
                var creatorUser = db.Users.FirstOrDefault(u => u.Id == creatorUserId);
                if (creatorUser == null)
                {
                    MessageBox.Show(_languageManager.GetString("UserNotFoundMessage", "Balda.Resources.MessageSources"));
                    return;
                }

                var newGame = new Game
                {
                    BoardState = boardState,
                    IsActive = true,
                    CurrentPlayerTurn = creatorUserId,
                    Users = [creatorUser],
                    InitialWord = initialWord
                };
                Logger.Info("Добавление игры в бд");
                db.Games.Add(newGame);
                db.SaveChanges();

                _gameId = newGame.Id;
                Clipboard.SetText(_gameId.ToString());
                MessageBox.Show(_languageManager.GetString("IdWasCopiedMessage", "Balda.Resources.MessageSources"));
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
                        MessageBox.Show(_languageManager.GetString("GameNotFoundMessage", "Balda.Resources.MessageSources"));
                        return;
                    }

                    if (game.Users.Any(p => p.Id == _userId))
                    {
                        MessageBox.Show(_languageManager.GetString("YouAlreadyInGameMessage", "Balda.Resources.MessageSources"));
                        return;
                    }

                    if (game.Users.Count >= 2)
                    {
                        MessageBox.Show(_languageManager.GetString("GameFullMessage", "Balda.Resources.MessageSources"));
                        return;
                    }

                    var user = db.Users.FirstOrDefault(u => u.Id == _userId);
                    if (user == null)
                    {
                        MessageBox.Show(_languageManager.GetString("UserNotFoundMessage", "Balda.Resources.MessageSources"));
                        return;
                    }

                    game.Users.Add(user);
                    db.SaveChanges();
                    Logger.Info($"Пользователь {_userId} присоединился к игре {gameId}");

                    OpenGameForm(gameId, _userId);

                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Не удалось подключиться к игре {gameId}");
                MessageBox.Show($"{_languageManager.GetString("ErrorMessagePrefix", "Balda.Resources.MessageSources")}: {ex.Message}");
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

        private void OpenGameForm(Guid gameId, Guid userId)
        {

            var gameForm = new GameForm(gameId, userId);
            gameForm.Show();
            this.Hide();
        }

        private string GetRandomFiveLetterWord()
        {
            // Надо подправить
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
