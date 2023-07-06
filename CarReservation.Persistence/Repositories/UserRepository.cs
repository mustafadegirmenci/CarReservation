using CarReservation.Application.Repositories;
using CarReservation.Persistence.Context;
using CarReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarReservation.Persistence.Repositories;


public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }
    
    public Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}