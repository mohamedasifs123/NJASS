using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto request)
        {
            await _service.Create(request);
            return Ok();
        }

        // ✅ GET: api/product
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAll();
            return Ok(products);
        }

        // ✅ GET: api/product/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _service.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto request)
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

    // DTOs for Product Controller
    // Moved to Application/DTOs/ProductDtos.cs
}
    