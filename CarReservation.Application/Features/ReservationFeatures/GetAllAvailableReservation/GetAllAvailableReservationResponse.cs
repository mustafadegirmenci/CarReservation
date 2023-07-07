using CarReservation.Domain.Entities;

namespace CarReservation.Application.Features.ReservationFeatures.GetAllAvailableReservation;

public sealed record GetAllAvailableReservationResponse
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<Car> AvailableReservations { get; set; }
}
