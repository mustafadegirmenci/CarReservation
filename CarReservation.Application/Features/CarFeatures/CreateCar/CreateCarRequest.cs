using MediatR;

namespace CarReservation.Application.Features.CarFeatures.CreateCar;

public sealed record CreateCarRequest(
    string Brand, 
    string Model) : IRequest<CreateCarResponse>;
