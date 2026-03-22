using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.DTOs;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> Create([FromBody] CreateUserDto request)
        {
            await _service.Create(request);
            return Ok();
        }

        // ✅ Get all users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAll();
            return Ok(users);
        }

        // ✅ Get user by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _service.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto request)
        {
            await _service.Update(id, request);
            return NoContent(); // 204 No Content for successful update with no return body
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return NoContent(); // 204 No Content for successful deletion
        }
    }

    // DTOs for User Controller
    // Moved to Application/DTOs/UserDtos.cs
}