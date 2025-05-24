namespace Balda
{
    public class Game
    {
        public Guid Id { get; set; }
        public List<UserEntity> Users { get; set; } = [];
        public required string InitialWord { get; set; }
        public required Guid CurrentPlayerTurn { get; set; }
        public required string BoardState { get; set; }
        public bool IsActive { get; set; }
    }
}
