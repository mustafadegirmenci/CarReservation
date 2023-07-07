using CarReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarReservation.Persistence.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
}
