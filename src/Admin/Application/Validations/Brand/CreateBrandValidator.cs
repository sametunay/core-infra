using FluentValidation;
using CI.Admin.Application.Dto.Create;

namespace CI.Admin.Application.Validations.Brand;

public class CreateBrandValidator : AbstractValidator<CreateBrandDto>
{
    public CreateBrandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().NotNull().Length(2, 20);

        When(x => string.IsNullOrWhiteSpace(x.National) == false, () =>
        {
            RuleFor(x => x.National).Length(10, 255);
        });
    }
}