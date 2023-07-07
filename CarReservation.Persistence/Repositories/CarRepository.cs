using CarReservation.Application.Repositories;
using CarReservation.Persistence.Context;
using CarReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarReservation.Persistence.Repositories;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(DataContext context) : base(context)
    {
    }
    
    public Task<Car?> GetByMake(string email, CancellationToken cancellationToken)
    {
        return Context.Cars.FirstOrDefaultAsync(x => x.Brand == email, cancellationToken);
    }
}
