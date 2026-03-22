using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreatePaymentDto
    {
        [Required(ErrorMessage = "Order ID is required for a payment.")]
        public Guid OrderId { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Payment method is required.")]
        [StringLength(50, ErrorMessage = "Payment method cannot exceed 50 characters.")]
        public string PaymentMethod { get; set; } = string.Empty;
        [Required(ErrorMessage = "Payment status is required.")]
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; } = "pending"; // Default status
        public string? TransactionId { get; set; }
    }

    public class UpdatePaymentDto
    {
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; } = string.Empty;
        public string? TransactionId { get; set; }
    }
}