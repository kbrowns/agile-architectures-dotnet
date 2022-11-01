using FluentValidation.Results;

namespace AA.Domain.Services.Validation;

public interface IRequestValidator<in T>
{
    ValidationResult Validate(T request);
}