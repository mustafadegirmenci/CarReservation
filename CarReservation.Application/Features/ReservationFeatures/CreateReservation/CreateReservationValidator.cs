using FluentValidation;

namespace CarReservation.Application.Features.ReservationFeatures.CreateReservation;

public sealed class CreateReservationValidator : AbstractValidator<CreateReservationRequest>
{
    public CreateReservationValidator()
    {
        RuleFor(x => x.StartTime).NotEmpty();
        RuleFor(x => x.EndTime).NotEmpty();
        RuleFor(x => DateTime.Now - x.StartTime).LessThanOrEqualTo(TimeSpan.FromHours(24));
        RuleFor(x => x.EndTime - x.StartTime).LessThanOrEqualTo(TimeSpan.FromHours(2));
    }
}
