using MediatR;

namespace CarReservation.Application.Features.ReservationFeatures.CreateReservation;

public sealed record CreateReservationRequest(
    DateTime StartTime, 
    DateTime EndTime) : IRequest<CreateReservationResponse>;
