using Domain.Entities;
using Application.DTOs;
using Infrastructure.UnitOfWork;

namespace Application.Services
{
    public class SessionService
    {
        private readonly IUnitOfWork _uow;

        public SessionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Create(CreateSessionDto sessionDto)
        {
            var user = await _uow.Repository<User>().GetAsync(sessionDto.UserId);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            var session = new Session
            {
                Id = Guid.NewGuid(),
                User = user,
                Token = sessionDto.Token,
                ExpiresAt = sessionDto.ExpiresAt,
                CreatedAt = DateTime.UtcNow
            };

            await _uow.Repository<Session>().AddAsync(session);
            await _uow.Commit();
        }

        public async Task<Session?> GetById(Guid id)
        {
            return await _uow.Repository<Session>().GetAsync(id);
        }

        public async Task<IEnumerable<Session>> GetAll()
        {
            return await _uow.Repository<Session>().GetAllAsync();
        }

        public async Task Update(Guid id, UpdateSessionDto sessionDto)
        {
            var session = await _uow.Repository<Session>().GetAsync(id);
            if (session == null) return;

            session.ExpiresAt = sessionDto.ExpiresAt;

            await _uow.Repository<Session>().UpdateAsync(session);
            await _uow.Commit();
        }

        public async Task Delete(Guid id)
        {
            var session = await _uow.Repository<Session>().GetAsync(id);
            if (session == null) return;
            await _uow.Repository<Session>().DeleteAsync(session);
            await _uow.Commit();
        }
    }
}