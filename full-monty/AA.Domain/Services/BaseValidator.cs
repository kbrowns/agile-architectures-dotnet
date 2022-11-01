using AA.Domain.Services.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace AA.Domain.Services;

public abstract class BaseValidator<T> : AbstractValidator<T>, IRequestValidator<T>
{
    public abstract ValidationResult ExecuteBusinessValidation(T request);

    public new ValidationResult Validate(T request)
    {
        var result = base.Validate(request);

        if (!result.IsValid)
            return result;
        
        var business = this.ExecuteBusinessValidation(request);

        if (!business.IsValid)
            return result;

        return result;
    }
}