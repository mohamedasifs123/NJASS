using System;

namespace Domain.Entities
{
    public class CartItem
    {
        public virtual Guid Id { get; set; }
        public virtual Cart Cart { get; set; } = null!; // Assuming Cart entity exists
        public virtual Product Product { get; set; } = null!; // Assuming Product entity exists
        public virtual int Quantity { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}