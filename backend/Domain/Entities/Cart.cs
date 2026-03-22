using System;

namespace Domain.Entities
{
    public class Cart
    {
        public virtual Guid Id { get; set; }
        public virtual User User { get; set; } = null!; // Assuming User entity exists
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}