using MediatR;

namespace CarReservation.Application.Features.CarFeatures.DeleteCar;

public sealed record DeleteCarRequest(Guid Id) : IRequest<DeleteCarResponse>;
