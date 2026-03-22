using Microsoft.AspNetCore.Mvc;
using Application.Services;

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
        public IActionResult Create(ProductRequest request)
        {
            _service.Create(request.Name, request.Price);
            return Ok();
        }
    }

    public class ProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}