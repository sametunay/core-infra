using FluentValidation;
using CI.Admin.Application.Dto.Update;

namespace CI.Admin.Application.Validations.CarCategory;

public class UpdateCarCategoryValidator : AbstractValidator<UpdateCarCategoryDto>
{
    public UpdateCarCategoryValidator()
    {
        RuleFor(x => x.Title).NotEmpty().NotNull().Length(2, 20);

        When(x => string.IsNullOrWhiteSpace(x.Description) == false, () =>
        {
            RuleFor(x => x.Description).Length(10, 255);
        });
    }
}