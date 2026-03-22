using Domain.Entities;
using Application.DTOs;
using Infrastructure.UnitOfWork;
using BCrypt.Net;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Create(CreateUserDto userDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = userDto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password), // ✅ secure
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            await _uow.Repository<User>().AddAsync(user);
            await _uow.Commit();
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _uow.Repository<User>().GetAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _uow.Repository<User>().GetAllAsync();
        }

        public async Task Update(Guid id, UpdateUserDto userDto)
        {
            var user = await _uow.Repository<User>().GetAsync(id);
            if (user == null) return;

            user.Username = userDto.Username;
            user.UpdatedAt = DateTime.UtcNow;

            await _uow.Repository<User>().UpdateAsync(user);
            await _uow.Commit();
        }

        public async Task Delete(Guid id)
        {
            var user = await _uow.Repository<User>().GetAsync(id);
            if (user == null) return;
            user.IsDeleted = true; // Soft delete
            await _uow.Repository<User>().UpdateAsync(user); // Update instead of Delete for soft delete
            await _uow.Commit();
        }
    }
}