using Domain.Entities;
using Application.DTOs;
using Infrastructure.UnitOfWork;
using NHibernate.Linq;

namespace Application.Services
{
    public class ProductCategoryService
    {
        private readonly IUnitOfWork _uow;

        public ProductCategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Create(CreateProductCategoryDto productCategoryDto)
        {
            var product = await _uow.Repository<Product>().GetAsync(productCategoryDto.ProductId);
            var category = await _uow.Repository<Category>().GetAsync(productCategoryDto.CategoryId);

            if (product == null) throw new ArgumentException("Product not found.");
            if (category == null) throw new ArgumentException("Category not found.");

            var productCategory = new ProductCategory
            {
                Product = product,
                Category = category,
                ProductId = productCategoryDto.ProductId, // Set for composite key
                CategoryId = productCategoryDto.CategoryId  // Set for composite key
            };

            await _uow.Repository<ProductCategory>().AddAsync(productCategory);
            await _uow.Commit();
        }

        public async Task<ProductCategory?> GetById(Guid productId, Guid categoryId)
        {
            // For composite keys, you might need a custom query or a specific method in the repository
            // For simplicity, let's assume a custom query for now.
            return await _uow.Repository<ProductCategory>().GetAllAsync()
                             .ContinueWith(t => t.Result.FirstOrDefault(pc => pc.ProductId == productId && pc.CategoryId == categoryId));
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            return await _uow.Repository<ProductCategory>().GetAllAsync();
        }

        public async Task Delete(Guid productId, Guid categoryId)
        {
            var productCategory = await GetById(productId, categoryId);
            if (productCategory == null) return;
            await _uow.Repository<ProductCategory>().DeleteAsync(productCategory);
            await _uow.Commit();
        }
    }
}