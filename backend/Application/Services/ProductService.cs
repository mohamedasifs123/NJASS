using Domain.Entities;
using Application.DTOs;
using Infrastructure.UnitOfWork;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Create(CreateProductDto productDto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Price = productDto.Price,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            await _uow.Repository<Product>().AddAsync(product);
            await _uow.Commit();
        }

        // ✅ Get all products
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _uow.Repository<Product>().GetAllAsync();
        }

      public async Task<Product?> GetById(Guid id)
      {
          return await _uow.Repository<Product>().GetAsync(id);
      }

        public async Task Update(Guid id, UpdateProductDto productDto)
        {
            var product = await _uow.Repository<Product>().GetAsync(id);
            if (product == null) return;

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.UpdatedAt = DateTime.UtcNow;

            await _uow.Repository<Product>().UpdateAsync(product);
            await _uow.Commit();
        }

        public async Task Delete(Guid id)
        {
            var product = await _uow.Repository<Product>().GetAsync(id);
            if (product == null) return;
            product.IsDeleted = true; // Soft delete
            await _uow.Repository<Product>().UpdateAsync(product); // Update instead of Delete for soft delete
            await _uow.Commit();
        }
}
    }
