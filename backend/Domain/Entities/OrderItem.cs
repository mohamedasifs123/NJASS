using System;

namespace Domain.Entities
{
    public class OrderItem
    {
        public virtual Guid Id { get; set; }
        public virtual Order Order { get; set; } = null!; // Assuming Order entity exists
        public virtual Product Product { get; set; } = null!; // Assuming Product entity exists
        public virtual int Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
    }
}