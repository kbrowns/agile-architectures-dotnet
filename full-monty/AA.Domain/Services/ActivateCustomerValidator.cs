using AA.Contracts;
using AA.Domain.Model;
using FluentValidation;
using FluentValidation.Results;

namespace AA.Domain.Services;

public class ActivateCustomerValidator : BaseValidator<ActivateCustomerRequest>
{
    public ActivateCustomerValidator()
    {
        this.RuleFor(x => x.CustomerId).NotEmpty();
    }
    public override ValidationResult ExecuteBusinessValidation(ActivateCustomerRequest request)
    {
        var result = new ValidationResult();
        var db = new Database();
        
        this.ResolvedCustomer = db.Customers.FirstOrDefault(x => x.Id == request.CustomerId);

        if (this.ResolvedCustomer == null)
        {
            result.Errors.Add(new ValidationFailure(nameof(request.CustomerId), "Customer not found"));
        }
        else
        {
            if(!this.ResolvedCustomer.CanActivate())
                result.Errors.Add(new ValidationFailure(nameof(request.CustomerId), "Customer not eligible for activation"));
        }
        
        return result;
    }

    public Customer ResolvedCustomer { get; set; }
}