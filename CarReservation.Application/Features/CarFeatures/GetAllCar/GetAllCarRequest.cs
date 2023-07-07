using MediatR;

namespace CarReservation.Application.Features.CarFeatures.GetAllCar;

public sealed record GetAllCarRequest : IRequest<GetAllCarResponse>;
