using FluentValidation;

namespace CarReservation.Application.Features.CarFeatures.UpdateCar;

public sealed class UpdateCarValidator : AbstractValidator<UpdateCarRequest>
{
    public UpdateCarValidator()
    {
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.Model).NotEmpty();
    }
}
