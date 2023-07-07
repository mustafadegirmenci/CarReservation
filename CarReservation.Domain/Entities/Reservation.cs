using CarReservation.Domain.Common;

namespace CarReservation.Domain.Entities;

public sealed class Reservation : BaseEntity
{
    public Guid CarId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime BookingTime { get; set; }
    public DateTime EndTime { get; set; }
}
