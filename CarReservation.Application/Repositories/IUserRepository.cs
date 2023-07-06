using CarReservation.Domain.Entities;

namespace CarReservation.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email, CancellationToken cancellationToken);
}