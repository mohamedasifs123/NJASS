using Domain.Entities;
using Application.DTOs;
using Infrastructure.UnitOfWork;

namespace Application.Services
{
    public class PaymentService
    {
        private readonly IUnitOfWork _uow;

        public PaymentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Create(CreatePaymentDto paymentDto)
        {
            var order = await _uow.Repository<Order>().GetAsync(paymentDto.OrderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found.");
            }

            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                Order = order,
                PaymentDate = DateTime.UtcNow,
                Amount = paymentDto.Amount,
                PaymentMethod = paymentDto.PaymentMethod,
                Status = paymentDto.Status,
                TransactionId = paymentDto.TransactionId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _uow.Repository<Payment>().AddAsync(payment);
            await _uow.Commit();
        }

        public async Task<Payment?> GetById(Guid id)
        {
            return await _uow.Repository<Payment>().GetAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetAll()
        {
            return await _uow.Repository<Payment>().GetAllAsync();
        }

        public async Task Update(Guid id, UpdatePaymentDto paymentDto)
        {
            var payment = await _uow.Repository<Payment>().GetAsync(id);
            if (payment == null) return;

            payment.Status = paymentDto.Status;
            payment.TransactionId = paymentDto.TransactionId;
            payment.UpdatedAt = DateTime.UtcNow;

            await _uow.Repository<Payment>().UpdateAsync(payment);
            await _uow.Commit();
        }

        public async Task Delete(Guid id)
        {
            var payment = await _uow.Repository<Payment>().GetAsync(id);
            if (payment == null) return;
            await _uow.Repository<Payment>().DeleteAsync(payment);
            await _uow.Commit();
        }
    }
}