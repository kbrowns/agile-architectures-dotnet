namespace AA.Contracts;

public class CreateCustomerRequest
{
    public string ExternalId { get; set; }
    public string Name { get; set; }
    public string EmailAddress { get; set; }
}