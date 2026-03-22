using Domain.Entities;
using Application.DTOs;
using Infrastructure.UnitOfWork;

namespace Application.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork _uow;

        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Create(CreateOrderDto orderDto)
        {
            var user = await _uow.Repository<User>().GetAsync(orderDto.UserId);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            var order = new Order
            {
                Id = Guid.NewGuid(),
                User = user,
                OrderDate = DateTime.UtcNow,
                TotalAmount = orderDto.TotalAmount,
                Status = orderDto.Status,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _uow.Repository<Order>().AddAsync(order);
            await _uow.Commit();
        }

        public async Task<Order?> GetById(Guid id)
        {
            return await _uow.Repository<Order>().GetAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _uow.Repository<Order>().GetAllAsync();
        }

        public async Task Update(Guid id, UpdateOrderDto orderDto)
        {
            var order = await _uow.Repository<Order>().GetAsync(id);
            if (order == null) return;

            order.TotalAmount = orderDto.TotalAmount;
            order.Status = orderDto.Status;
            order.UpdatedAt = DateTime.UtcNow;

            await _uow.Repository<Order>().UpdateAsync(order);
            await _uow.Commit();
        }

        public async Task Delete(Guid id)
        {
            var order = await _uow.Repository<Order>().GetAsync(id);
            if (order == null) return;
            await _uow.Repository<Order>().DeleteAsync(order);
            await _uow.Commit();
        }
    }
}