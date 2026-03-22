using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateCartItemDto
    {
        [Required(ErrorMessage = "Cart ID is required.")]
        public Guid CartId { get; set; }
        [Required(ErrorMessage = "Product ID is required.")]
        public Guid ProductId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }

    public class UpdateCartItemDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}