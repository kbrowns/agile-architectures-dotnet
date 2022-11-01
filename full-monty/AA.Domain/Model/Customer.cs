namespace AA.Domain.Model;

public class Customer : DomainEntity
{
     protected Customer() { /* needed by ef */ }

     public Customer(string name, string email, string externalId)
     {
          this.Name = name;
          this.EmailAddress = email;
          this.ExternalId = externalId;
          this.Status = CustomerStatuses.Created;
     }
     
     public CustomerStatuses Status { get; protected set; }
     public string Name { get; protected set; }

     public string EmailAddress { get; protected set; }

     public void Activate()
     {
          this.Status = CustomerStatuses.Activated;
     }

     public ICollection<Order> Orders { get; protected set; } = new List<Order>();

     public bool CanActivate()
     {
          return this.Status is CustomerStatuses.Created or CustomerStatuses.Deactivated or CustomerStatuses.Suspended;
     }
}

public enum CustomerStatuses
{
     Created,
     Activated,
     Deactivated,
     Suspended
}