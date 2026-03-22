using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateProductCategoryDto
    {
        [Required(ErrorMessage = "Product ID is required.")]
        public Guid ProductId { get; set; }
        [Required(ErrorMessage = "Category ID is required.")]
        public Guid CategoryId { get; set; }
    }
    // UpdateProductCategoryDto is not typically needed for a junction table.
}