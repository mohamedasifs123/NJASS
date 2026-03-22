using Domain.Entities;
using Application.DTOs;
using Infrastructure.UnitOfWork;

namespace Application.Services
{
    public class CartItemService
    {
        private readonly IUnitOfWork _uow;

        public CartItemService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Create(CreateCartItemDto cartItemDto)
        {
            var cart = await _uow.Repository<Cart>().GetAsync(cartItemDto.CartId);
            var product = await _uow.Repository<Product>().GetAsync(cartItemDto.ProductId);

            if (cart == null) throw new ArgumentException("Cart not found.");
            if (product == null) throw new ArgumentException("Product not found.");

            var cartItem = new CartItem
            {
                Id = Guid.NewGuid(),
                Cart = cart,
                Product = product,
                Quantity = cartItemDto.Quantity,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _uow.Repository<CartItem>().AddAsync(cartItem);
            await _uow.Commit();
        }

        public async Task<CartItem?> GetById(Guid id)
        {
            return await _uow.Repository<CartItem>().GetAsync(id);
        }

        public async Task<IEnumerable<CartItem>> GetAll()
        {
            return await _uow.Repository<CartItem>().GetAllAsync();
        }

        public async Task Update(Guid id, UpdateCartItemDto cartItemDto)
        {
            var cartItem = await _uow.Repository<CartItem>().GetAsync(id);
            if (cartItem == null) return;

            cartItem.Quantity = cartItemDto.Quantity;
            cartItem.UpdatedAt = DateTime.UtcNow;

            await _uow.Repository<CartItem>().UpdateAsync(cartItem);
            await _uow.Commit();
        }

        public async Task Delete(Guid id)
        {
            var cartItem = await _uow.Repository<CartItem>().GetAsync(id);
            if (cartItem == null) return;
            await _uow.Repository<CartItem>().DeleteAsync(cartItem);
            await _uow.Commit();
        }
    }
}