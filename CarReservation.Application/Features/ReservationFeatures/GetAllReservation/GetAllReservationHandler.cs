using CarReservation.Application.Repositories;
using MediatR;

namespace CarReservation.Application.Features.ReservationFeatures.GetAllReservation;

public class GetAllReservationHandler : IRequestHandler<GetAllReservationRequest, GetAllReservationResponse>
{
    private readonly IReservationRepository _reservationRepository;

    public GetAllReservationHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    public async Task<GetAllReservationResponse> Handle(GetAllReservationRequest request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetAll(cancellationToken);
        return new GetAllReservationResponse { Reservations = reservations };
    }
}
