using AutoMapper;
using CarReservation.Application.Repositories;
using MediatR;

namespace CarReservation.Application.Features.CarFeatures.DeleteCar;

public sealed class DeleteCarHandler : IRequestHandler<DeleteCarRequest, DeleteCarResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public DeleteCarHandler(IUnitOfWork unitOfWork, ICarRepository carRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _carRepository = carRepository;
        _mapper = mapper;
    }
    
    public async Task<DeleteCarResponse> Handle(DeleteCarRequest request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.Get(request.Id, cancellationToken);
        if (car != null)
        {
            _carRepository.Delete(car);
            await _unitOfWork.Save(cancellationToken);
        }
        
        return _mapper.Map<DeleteCarResponse>(car);
    }
}
