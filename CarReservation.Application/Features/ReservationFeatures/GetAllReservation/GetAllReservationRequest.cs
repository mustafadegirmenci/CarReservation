using MediatR;

namespace CarReservation.Application.Features.ReservationFeatures.GetAllReservation;

public sealed record GetAllReservationRequest : IRequest<GetAllReservationResponse>;
