using AutoMapper;
using CarReservation.Domain.Entities;

namespace CarReservation.Application.Features.ReservationFeatures.CreateReservation;

public sealed class CreateReservationMapper : Profile
{
    public CreateReservationMapper()
    {
        CreateMap<CreateReservationRequest, Reservation>();
        CreateMap<Reservation, CreateReservationResponse>();
    }
}