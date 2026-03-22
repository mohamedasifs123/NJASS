using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateCartDto
    {
        [Required(ErrorMessage = "User ID is required for a cart.")]
        public Guid UserId { get; set; }
    }
    // UpdateCartDto is generally not needed for a cart itself, as items are managed separately.
}