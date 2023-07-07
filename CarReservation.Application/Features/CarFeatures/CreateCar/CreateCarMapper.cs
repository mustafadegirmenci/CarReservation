using AutoMapper;
using CarReservation.Domain.Entities;

namespace CarReservation.Application.Features.CarFeatures.CreateCar;

public sealed class CreateCarMapper : Profile
{
    public CreateCarMapper()
    {
        CreateMap<CreateCarRequest, Car>();
        CreateMap<Car, CreateCarResponse>();
    }
}
