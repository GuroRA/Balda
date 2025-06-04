namespace Balda
{
    /// <summary>
    /// Шаблон пользователя
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Id игрока
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя игрока (его логин)
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Пароль игрока
        /// </summary>
        public required string Password { get; set; }
        /// <summary>
        /// Колличество очков
        /// </summary>
        public int Score { get; set; }

    }
}
