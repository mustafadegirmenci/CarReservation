using MediatR;

namespace CarReservation.Application.Features.ReservationFeatures.GetAllAvailableReservation;

public sealed record GetAllAvailableReservationRequest(
    DateTime StartTime,
    DateTime EndTime
) : IRequest<GetAllAvailableReservationResponse>;
