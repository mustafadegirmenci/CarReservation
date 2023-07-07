namespace CarReservation.Application.Features.CarFeatures.DeleteCar;

public sealed record DeleteCarResponse
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}
