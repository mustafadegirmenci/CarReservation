using CarReservation.Application.Repositories;
using CarReservation.Persistence.Context;
using CarReservation.Domain.Entities;

namespace CarReservation.Persistence.Repositories;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(DataContext context) : base(context)
    {
    }
}
