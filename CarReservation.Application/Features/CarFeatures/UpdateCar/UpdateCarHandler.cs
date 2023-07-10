using AutoMapper;
using CarReservation.Application.Repositories;
using CarReservation.Domain.Entities;
using MediatR;

namespace CarReservation.Application.Features.CarFeatures.UpdateCar;

public sealed class UpdateCarHandler : IRequestHandler<UpdateCarRequest, UpdateCarResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public UpdateCarHandler(IUnitOfWork unitOfWork, ICarRepository carRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _carRepository = carRepository;
        _mapper = mapper;
    }
    
    public async Task<UpdateCarResponse> Handle(UpdateCarRequest request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.Get(request.Id, cancellationToken);
        if (car != null)
        {        
            _mapper.Map(request, car);

            _carRepository.Update(car);
            await _unitOfWork.Save(cancellationToken);
        }
            
        return _mapper.Map<UpdateCarResponse>(car);
    }
}
