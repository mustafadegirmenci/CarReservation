using AutoMapper;
using CarReservation.Domain.Entities;

namespace CarReservation.Application.Features.CarFeatures.UpdateCar;

public sealed class UpdateCarMapper : Profile
{
    public UpdateCarMapper()
    {
        CreateMap<UpdateCarRequest, Car>();
        CreateMap<Car, UpdateCarResponse>();
    }
}
