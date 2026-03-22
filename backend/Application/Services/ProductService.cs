using Domain.Entities;
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

        public void Create(string name, decimal price)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price
            };

            _uow.Repository<Product>().Add(product);
            _uow.Commit();
        }
    }
}