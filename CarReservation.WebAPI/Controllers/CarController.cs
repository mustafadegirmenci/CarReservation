using CarReservation.Application.Features.CarFeatures.CreateCar;
using CarReservation.Application.Features.CarFeatures.DeleteCar;
using CarReservation.Application.Features.CarFeatures.GetAllCar;
using CarReservation.Application.Features.CarFeatures.UpdateCar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarReservation.Controllers;

[ApiController]
[Route("car")]
public class CarController : ControllerBase
{
    private readonly IMediator _mediator;

    public CarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllCarResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllCarRequest(), cancellationToken);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateCarResponse>> Create(CreateCarRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<CreateCarResponse>> Update(UpdateCarRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpDelete]
    public async Task<ActionResult<CreateCarResponse>> Delete(DeleteCarRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
