using AutoMapper;
using CarReservation.Application.Repositories;
using CarReservation.Domain.Entities;
using MediatR;

namespace CarReservation.Application.Features.ReservationFeatures.CreateReservation;

public class CreateReservationHandler : IRequestHandler<CreateReservationRequest, CreateReservationResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;
    
    public CreateReservationHandler(IUnitOfWork unitOfWork, IReservationRepository reservationRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateReservationResponse> Handle(CreateReservationRequest request, CancellationToken cancellationToken)
    {
        var reservation = _mapper.Map<Reservation>(request);
        reservation.BookingTime = DateTime.Now;
        
        _reservationRepository.Create(reservation);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateReservationResponse>(reservation);
    }
}
