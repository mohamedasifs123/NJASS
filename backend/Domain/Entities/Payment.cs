using System;

namespace Domain.Entities
{
    public class Payment
    {
        public virtual Guid Id { get; set; }
        public virtual Order Order { get; set; } = null!; // Assuming Order entity exists
        public virtual DateTime PaymentDate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string PaymentMethod { get; set; } = string.Empty;
        public virtual string Status { get; set; } = string.Empty;
        public virtual string? TransactionId { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}