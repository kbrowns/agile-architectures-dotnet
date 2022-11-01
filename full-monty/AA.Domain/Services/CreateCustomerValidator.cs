using AA.Contracts;
using FluentValidation.Results;

namespace AA.Domain.Services;

public class CreateCustomerValidator : BaseValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        this.RuleFor(x => x.Name);
        this.RuleFor(x => x.EmailAddress);
        this.RuleFor(x => x.ExternalId);
    }
    public override ValidationResult ExecuteBusinessValidation(CreateCustomerRequest request)
    {
        var result = new ValidationResult();

        var db = new Database();
        var existing = db.Customers.FirstOrDefault(x => x.ExternalId == request.ExternalId);

        if (existing != null)
            result.Errors.Add(new ValidationFailure(nameof(request.ExternalId), "ExternalId is already taken"));

        return result;
    }
}