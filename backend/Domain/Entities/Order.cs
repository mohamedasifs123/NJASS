using System;

namespace Domain.Entities
{
    public class Order
    {
        public virtual Guid Id { get; set; }
        public virtual User User { get; set; } = null!; // Assuming User entity exists
        public virtual DateTime OrderDate { get; set; }
        public virtual decimal TotalAmount { get; set; }
        public virtual string Status { get; set; } = string.Empty;
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}