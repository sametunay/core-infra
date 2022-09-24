using FluentValidation;
using CI.Admin.Application.Dto.Create;

namespace CI.Admin.Application.Validations.Car;

public class CreateCarValidator : AbstractValidator<CreateCarDto>
{
    public CreateCarValidator()
    {

        RuleFor(x => x.Name).NotNull().NotEmpty().Length(2, 50);

        RuleFor(x => x.PowerInfo).NotNull();
        RuleFor(x => x.PowerInfo.Engine).NotNull().ChildRules(c =>
        {
            c.RuleFor(e => e.CylinderVolume).InclusiveBetween(0, 7000);
            c.RuleFor(e => e.MaxPower).InclusiveBetween(0, 7000);
            c.RuleFor(e => e.MaxTorque).InclusiveBetween(0, 7000);
        });

        RuleFor(x => x.PowerInfo.MaxSpeed).InclusiveBetween(0, 500);

        RuleFor(x => x.BrandId).NotNull().NotEmpty().GreaterThan(0).WithMessage("Lütfen geçerli bir BrandId giriniz.");
        RuleFor(x => x.CarCategoryId).NotNull().NotEmpty().GreaterThan(0).WithMessage("Lütfen geçerli bir CarCategoryId giriniz.");
    }
}