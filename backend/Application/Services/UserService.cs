using Domain.Entities;
using Infrastructure.UnitOfWork;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Create(string username, string password)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = password
            };

            _uow.Repository<User>().Add(user);
            _uow.Commit();
        }
    }
}