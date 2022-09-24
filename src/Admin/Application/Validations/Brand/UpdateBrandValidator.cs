using FluentValidation;
using CI.Admin.Application.Dto.Update;

namespace CI.Admin.Application.Validations.Brand;

public class UpdateBrandValidator : AbstractValidator<UpdateBrandDto>
{
    public UpdateBrandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().NotNull().Length(2, 20);

        When(x => string.IsNullOrWhiteSpace(x.National) == false, () =>
        {
            RuleFor(x => x.National).Length(10, 255);
        });
    }
}