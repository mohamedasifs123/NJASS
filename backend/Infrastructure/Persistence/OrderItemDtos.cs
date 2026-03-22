using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateOrderItemDto
    {
        [Required(ErrorMessage = "Order ID is required.")]
        public Guid OrderId { get; set; }
        [Required(ErrorMessage = "Product ID is required.")]
        public Guid ProductId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        [Range(0.00, double.MaxValue, ErrorMessage = "Unit price cannot be negative.")]
        public decimal UnitPrice { get; set; }
    }

    public class UpdateOrderItemDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        [Range(0.00, double.MaxValue, ErrorMessage = "Unit price cannot be negative.")]
        public decimal UnitPrice { get; set; }
    }
}