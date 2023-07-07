using AutoMapper;
using CarReservation.Domain.Entities;

namespace CarReservation.Application.Features.CarFeatures.DeleteCar;

public sealed class DeleteCarMapper : Profile
{
    public DeleteCarMapper()
    {
        CreateMap<Car, DeleteCarResponse>();
    }
}
