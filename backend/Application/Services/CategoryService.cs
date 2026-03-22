using Domain.Entities;
using Application.DTOs;
using Infrastructure.UnitOfWork;

namespace Application.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Create(CreateCategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            await _uow.Repository<Category>().AddAsync(category);
            await _uow.Commit();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await _uow.Repository<Category>().GetAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _uow.Repository<Category>().GetAllAsync();
        }

        public async Task Update(Guid id, UpdateCategoryDto categoryDto)
        {
            var category = await _uow.Repository<Category>().GetAsync(id);
            if (category == null) return;

            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;

            await _uow.Repository<Category>().UpdateAsync(category);
            await _uow.Commit();
        }

        public async Task Delete(Guid id)
        {
            var category = await _uow.Repository<Category>().GetAsync(id);
            if (category == null) return;
            await _uow.Repository<Category>().DeleteAsync(category);
            await _uow.Commit();
        }
    }
}