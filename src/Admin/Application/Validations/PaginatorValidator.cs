using FluentValidation;
using MyGallery.Core.Domain.Dto;

namespace MyGallery.Admin.Application.Validations;

public class PaginatorValidator : AbstractValidator<PaginatorDto>
{
    public PaginatorValidator()
    {
        When(x => x.PageIndex != default, () => RuleFor(x => x.PageIndex).NotNull().GreaterThanOrEqualTo(0));
        When(x => x.PageSize != default, () => RuleFor(x => x.PageSize).NotNull().InclusiveBetween(5, byte.MaxValue));
    }
}