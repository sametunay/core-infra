using FluentValidation;
using CI.Admin.Application.Dto.Update;

namespace CI.Admin.Application.Validations.Car;

public class UpdateCarValidator : AbstractValidator<UpdateCarDto>
{
    public UpdateCarValidator()
    {

        RuleFor(x => x.Name).NotNull().NotEmpty();

        RuleFor(x => x.PowerInfo).NotNull();
        RuleFor(x => x.PowerInfo.Engine).NotNull().ChildRules(c =>
        {
            c.RuleFor(e => e.CylinderVolume).InclusiveBetween(0, 7000);
            c.RuleFor(e => e.MaxPower).InclusiveBetween(0, 7000);
            c.RuleFor(e => e.MaxTorque).InclusiveBetween(0, 7000);
        });

        RuleFor(x => x.PowerInfo.MaxSpeed).InclusiveBetween(0, 500);

        RuleFor(x => x.BrandId).NotNull().NotEmpty().LessThanOrEqualTo(0);
        RuleFor(x => x.CarCategoryId).NotNull().NotEmpty().LessThanOrEqualTo(0);
    }
}