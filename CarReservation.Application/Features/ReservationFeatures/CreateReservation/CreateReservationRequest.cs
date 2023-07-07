using MediatR;

namespace CarReservation.Application.Features.ReservationFeatures.CreateReservation;

public sealed record CreateReservationRequest(
    Guid CarId,
    DateTime StartTime,
    DateTime EndTime
) : IRequest<CreateReservationResponse>;
