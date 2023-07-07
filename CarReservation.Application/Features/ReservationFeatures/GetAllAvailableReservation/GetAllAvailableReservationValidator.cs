using FluentValidation;

namespace CarReservation.Application.Features.ReservationFeatures.GetAllAvailableReservation;

public sealed class GetAllAvailableReservationValidator : AbstractValidator<GetAllAvailableReservationRequest>
{
    public GetAllAvailableReservationValidator()
    {
        RuleFor(x => x.StartTime).NotEmpty();
        RuleFor(x => x.EndTime).NotEmpty();
        RuleFor(x => x.EndTime > x.StartTime);
    }
}
