using Domain.Entities;
using Application.DTOs;
using Infrastructure.UnitOfWork;

namespace Application.Services
{
    public class CartService
    {
        private readonly IUnitOfWork _uow;

        public CartService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Create(CreateCartDto cartDto)
        {
            var user = await _uow.Repository<User>().GetAsync(cartDto.UserId);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            var cart = new Cart
            {
                Id = Guid.NewGuid(),
                User = user,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _uow.Repository<Cart>().AddAsync(cart);
            await _uow.Commit();
        }

        public async Task<Cart?> GetById(Guid id)
        {
            return await _uow.Repository<Cart>().GetAsync(id);
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _uow.Repository<Cart>().GetAllAsync();
        }

        // Update method is typically not directly on the cart, but rather on its items.
        // If there were properties on Cart other than timestamps and User, an UpdateCartDto would be created.

        public async Task Delete(Guid id)
        {
            var cart = await _uow.Repository<Cart>().GetAsync(id);
            if (cart == null) return;
            await _uow.Repository<Cart>().DeleteAsync(cart);
            await _uow.Commit();
        }
    }
}