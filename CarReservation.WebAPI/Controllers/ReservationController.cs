using CarReservation.Application.Features.ReservationFeatures.CreateReservation;
using CarReservation.Application.Features.ReservationFeatures.GetAllAvailableReservation;
using CarReservation.Application.Features.ReservationFeatures.GetAllReservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarReservation.Controllers;

[ApiController]
[Route("reservation")]
public class ReservationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllReservationResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllReservationRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    [Route("Available")]
    public async Task<ActionResult<List<GetAllAvailableReservationResponse>>> GetAvailable(
        [FromQuery]GetAllAvailableReservationRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateReservationResponse>> Create(CreateReservationRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
