using FluentValidation;

namespace MyGallery.Admin.Application.Validations.CustomeValidations;

public static class PropertyValidatorExtensions
{
    public static IRuleBuilderOptions<T1, int> Range<T1>(this IRuleBuilder<T1, int> ruleBuilder, int minValue = int.MinValue, int maxValue = int.MaxValue, string message = null)
    {        
        return ruleBuilder.SetValidator(new Range<T1>(minValue, maxValue));
    }

    public static IRuleBuilderOptions<T1, int?> Range<T1>(this IRuleBuilder<T1, int?> ruleBuilder, int minValue = int.MinValue, int maxValue = int.MaxValue, string message = null)
    {        
        return ruleBuilder.SetValidator(new Range<T1>(minValue, maxValue));
    }
}