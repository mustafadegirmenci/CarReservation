using CarReservation.Domain.Common;

namespace CarReservation.Domain.Entities;

public sealed class Reservation : BaseEntity
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
