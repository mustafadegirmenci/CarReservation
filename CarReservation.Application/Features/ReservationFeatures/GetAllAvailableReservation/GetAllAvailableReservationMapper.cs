using AutoMapper;

namespace CarReservation.Application.Features.ReservationFeatures.GetAllAvailableReservation;

public sealed class GetAllAvailableReservationMapper : Profile
{
    public GetAllAvailableReservationMapper()
    {
        CreateMap<GetAllAvailableReservationRequest, GetAllAvailableReservationResponse>();
    }
}
