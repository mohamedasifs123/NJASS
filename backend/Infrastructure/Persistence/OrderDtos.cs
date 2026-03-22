using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "User ID is required for an order.")]
        public Guid UserId { get; set; }
        [Range(0.00, double.MaxValue, ErrorMessage = "Total amount cannot be negative.")]
        public decimal TotalAmount { get; set; }
        [Required(ErrorMessage = "Order status is required.")]
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; } = "pending"; // Default status
    }

    public class UpdateOrderDto
    {
        [Range(0.00, double.MaxValue, ErrorMessage = "Total amount cannot be negative.")]
        public decimal TotalAmount { get; set; }
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; } = string.Empty;
    }
}