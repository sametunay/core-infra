using FluentValidation;
using FluentValidation.Validators;

namespace CI.Admin.Application.Validations.CustomeValidations;


// TODO: Yazılmış zaten :D
public class Range<T1> : PropertyValidator<T1, int>
{
    private int minValue;
    private int maxValue;
    private string message;

    public Range(int minValue, int maxValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
        message = $"{minValue}-{maxValue} arasında olmalıdır.";
    }

    public Range(int minValue, int maxValue, string message)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.message = message;
    }

    public override string Name => nameof(Range);

    public override bool IsValid(ValidationContext<T1> context, int value)
    {
        return value >= minValue && value <= maxValue;
    }

    public bool IsValid(ValidationContext<T1> context, int? value)
    {
        return value.HasValue && value >= minValue && value <= maxValue;
    }

    protected override string GetDefaultMessageTemplate(string errorCode) => message;
}