namespace CarReservation.Application.Features.CarFeatures.UpdateCar;

public sealed record UpdateCarResponse
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}
