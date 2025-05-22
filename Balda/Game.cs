namespace Balda
{
    public class Game
    {
        public Guid Id { get; set; }
        public List<UserEntity> Users { get; set; } = [];
    }
}
