namespace CarReservation.Application.Features.CarFeatures.CreateCar;

public sealed record CreateCarResponse
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}
