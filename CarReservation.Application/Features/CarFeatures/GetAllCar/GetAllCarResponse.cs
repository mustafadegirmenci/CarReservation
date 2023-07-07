using CarReservation.Domain.Entities;

namespace CarReservation.Application.Features.CarFeatures.GetAllCar;

public sealed record GetAllCarResponse
{
    public List<Car> Cars { get; set; }
}
