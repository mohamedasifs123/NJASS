using Domain.Entities;
using Application.DTOs;
using Infrastructure.UnitOfWork;

namespace Application.Services
{
    public class OrderItemService
    {
        private readonly IUnitOfWork _uow;

        public OrderItemService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Create(CreateOrderItemDto orderItemDto)
        {
            var order = await _uow.Repository<Order>().GetAsync(orderItemDto.OrderId);
            var product = await _uow.Repository<Product>().GetAsync(orderItemDto.ProductId);

            if (order == null) throw new ArgumentException("Order not found.");
            if (product == null) throw new ArgumentException("Product not found.");

            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                Order = order,
                Product = product,
                Quantity = orderItemDto.Quantity,
                UnitPrice = orderItemDto.UnitPrice
            };

            await _uow.Repository<OrderItem>().AddAsync(orderItem);
            await _uow.Commit();
        }

        public async Task<OrderItem?> GetById(Guid id)
        {
            return await _uow.Repository<OrderItem>().GetAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            return await _uow.Repository<OrderItem>().GetAllAsync();
        }

        public async Task Update(Guid id, UpdateOrderItemDto orderItemDto)
        {
            var orderItem = await _uow.Repository<OrderItem>().GetAsync(id);
            if (orderItem == null) return;

            orderItem.Quantity = orderItemDto.Quantity;
            orderItem.UnitPrice = orderItemDto.UnitPrice;

            await _uow.Repository<OrderItem>().UpdateAsync(orderItem);
            await _uow.Commit();
        }

        public async Task Delete(Guid id)
        {
            var orderItem = await _uow.Repository<OrderItem>().GetAsync(id);
            if (orderItem == null) return;
            await _uow.Repository<OrderItem>().DeleteAsync(orderItem);
            await _uow.Commit();
        }
    }
}