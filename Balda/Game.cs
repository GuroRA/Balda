namespace Balda
{
    /// <summary>
    /// Модель игры
    /// </summary>
    public class Game
    {

        /// <summary>
        /// Id игры
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Список игроков (Реализованно для 2)
        /// </summary>
        public List<UserEntity> Users { get; set; } = [];
        /// <summary>
        /// Стартовое слово
        /// </summary>
        public required string InitialWord { get; set; }
        /// <summary>
        /// Id Нынешнего хода игрока
        /// </summary>
        public required Guid CurrentPlayerTurn { get; set; }
        /// <summary>
        /// Состояние поля (массив с буквами в верхнем регистре)
        /// </summary>
        public required string BoardState { get; set; }
        /// <summary>
        /// Активность игры (для возможности подключится к игре)
        /// </summary>
        public bool IsActive { get; set; }
    }
}
