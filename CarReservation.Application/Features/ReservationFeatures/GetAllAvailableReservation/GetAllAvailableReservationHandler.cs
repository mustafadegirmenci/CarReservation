using AutoMapper;
using CarReservation.Application.Repositories;
using MediatR;

namespace CarReservation.Application.Features.ReservationFeatures.GetAllAvailableReservation;

public class GetAllAvailableReservationHandler : IRequestHandler<GetAllAvailableReservationRequest, GetAllAvailableReservationResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public GetAllAvailableReservationHandler(ICarRepository carRepository, IReservationRepository reservationRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }
    
    public async Task<GetAllAvailableReservationResponse> Handle(GetAllAvailableReservationRequest request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetAll(cancellationToken);
        var availableCarIds =
            reservations
                .Where(r => r.StartTime > request.EndTime || request.StartTime > r.EndTime)
                .Select(r => r.CarId);

        var availableCars = await _carRepository.GetMultiple(availableCarIds, cancellationToken);

        var response = _mapper.Map<GetAllAvailableReservationResponse>(request);
        response.AvailableReservations = availableCars;
        
        return response;
    }
}
