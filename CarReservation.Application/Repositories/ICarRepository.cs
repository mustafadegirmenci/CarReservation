using CarReservation.Domain.Entities;

namespace CarReservation.Application.Repositories;

public interface ICarRepository : IBaseRepository<Car>
{
    Task<Car?> GetByMake(string make, CancellationToken cancellationToken);
}
