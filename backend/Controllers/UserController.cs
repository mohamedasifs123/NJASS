using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(CreateUserRequest request)
        {
            _service.Create(request.Username, request.Password);
            return Ok();
        }
    }

    public class CreateUserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}