using AutoMapper;
using CarReservation.Application.Repositories;
using MediatR;

namespace CarReservation.Application.Features.CarFeatures.GetAllCar;

public class GetAllCarHandler : IRequestHandler<GetAllCarRequest, GetAllCarResponse>
{
    private readonly ICarRepository _carRepository;

    public GetAllCarHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public async Task<GetAllCarResponse> Handle(GetAllCarRequest request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAll(cancellationToken);
        return new GetAllCarResponse { Cars = cars };
    }
}
