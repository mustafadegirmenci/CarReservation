using CarReservation.Domain.Common;

namespace CarReservation.Domain.Entities;

public sealed class Car : BaseEntity
{
    public string Brand { get; set; }
    public string Model { get; set; }
}
