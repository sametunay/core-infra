using FluentValidation;
using CI.Admin.Application.Dto.Create;

namespace CI.Admin.Application.Validations.CarCategory;

public class CreateCarCategoryValidator : AbstractValidator<CreateCarCategoryDto>
{
    public CreateCarCategoryValidator()
    {
        RuleFor(x => x.Title).NotEmpty().NotNull().Length(2, 20);

        When(x => string.IsNullOrWhiteSpace(x.Description) == false, () =>
        {
            RuleFor(x => x.Description).Length(10, 255);
        });
    }
}