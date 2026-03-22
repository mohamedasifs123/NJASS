namespace Domain.Entities
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual string Username { get; set; } = string.Empty;
        public virtual string PasswordHash { get; set; } = string.Empty;
    }
}