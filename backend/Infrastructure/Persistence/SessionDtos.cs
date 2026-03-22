using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateSessionDto
    {
        [Required(ErrorMessage = "User ID is required for a session.")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Session token is required.")]
        public string Token { get; set; } = string.Empty;
        [Required(ErrorMessage = "Expiration date is required.")]
        public DateTime ExpiresAt { get; set; }
    }

    public class UpdateSessionDto
    {
        [Required(ErrorMessage = "Expiration date is required.")]
        public DateTime ExpiresAt { get; set; }
    }
}