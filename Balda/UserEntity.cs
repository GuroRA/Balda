namespace Balda
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
        public int Score { get; set; }

    }
}
