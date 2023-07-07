using CarReservation.Application.Repositories;
using CarReservation.Domain.Entities;
using CarReservation.Persistence.Context;

namespace CarReservation.Persistence.Repositories;

public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(DataContext context) : base(context)
    {
    }
    
    // public Task<Reservation?> GetByMake(string email, CancellationToken cancellationToken)
    // {
    //     return Context.Cars.FirstOrDefaultAsync(x => x.Brand == email, cancellationToken);
    // }
}
