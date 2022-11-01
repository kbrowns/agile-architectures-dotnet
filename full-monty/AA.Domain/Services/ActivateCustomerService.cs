using AA.Contracts;
using AA.Domain.Services.Validation;

namespace AA.Domain.Services;

public class ActivateCustomerService : DomainService<ActivateCustomerRequest, ActivateCustomerResponse>
{
    private readonly ActivateCustomerValidator _validator = new ActivateCustomerValidator();
    
    public override ActivateCustomerResponse Execute(ActivateCustomerRequest request)
    {
        var db = new Database();
        var customer = _validator.ResolvedCustomer;
        db.Attach(customer);
        customer.Activate();

        db.SaveChanges();

        return new ActivateCustomerResponse();
    }

    public override IRequestValidator<ActivateCustomerRequest> GetRequestValidator()
    {
        return _validator;
    }
}