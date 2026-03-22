using System;

namespace Domain.Entities
{
    public class Session
    {
        public virtual Guid Id { get; set; }
        public virtual User User { get; set; } = null!; // Assuming User entity exists
        public virtual string Token { get; set; } = string.Empty;
        public virtual DateTime ExpiresAt { get; set; }
        public virtual DateTime CreatedAt { get; set; }
    }
}