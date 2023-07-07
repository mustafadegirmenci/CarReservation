using MediatR;

namespace CarReservation.Application.Features.CarFeatures.UpdateCar;

public sealed record UpdateCarRequest(
    Guid Id,
    string Brand, 
    string Model) : IRequest<UpdateCarResponse>;

