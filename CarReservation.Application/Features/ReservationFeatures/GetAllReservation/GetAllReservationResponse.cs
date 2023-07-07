using CarReservation.Domain.Entities;

namespace CarReservation.Application.Features.ReservationFeatures.GetAllReservation;


public sealed record GetAllReservationResponse
{
    public List<Reservation> Reservations { get; set; }
}
