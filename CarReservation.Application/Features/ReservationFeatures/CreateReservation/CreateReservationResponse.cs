namespace CarReservation.Application.Features.ReservationFeatures.CreateReservation;

public sealed record CreateReservationResponse
{
    public Guid Id { get; set; }
    public DateTime BookingTime { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
