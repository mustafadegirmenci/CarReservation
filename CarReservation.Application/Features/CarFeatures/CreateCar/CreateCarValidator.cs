using FluentValidation;

namespace CarReservation.Application.Features.CarFeatures.CreateCar;

public sealed class CreateCarValidator : AbstractValidator<CreateCarRequest>
{
    public CreateCarValidator()
    {
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.Model).NotEmpty();
    }
}
