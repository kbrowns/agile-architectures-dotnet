using AA.Contracts;
using AA.Domain.Model;
using AA.Domain.Services.Validation;

namespace AA.Domain.Services;

public class CreateCustomerService : DomainService<CreateCustomerRequest,CreateCustomerResponse>
{
    public override CreateCustomerResponse Execute(CreateCustomerRequest request)
    {
        var database = new Database();
        var customer = new Customer(request.Name, request.EmailAddress, request.ExternalId);

        database.Customers.Add(customer);

        database.SaveChanges();

        return new CreateCustomerResponse { CustomerId = customer.Id };
    }

    public override IRequestValidator<CreateCustomerRequest> GetRequestValidator()
    {
        return new CreateCustomerValidator();
    }
}