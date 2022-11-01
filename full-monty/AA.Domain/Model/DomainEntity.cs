namespace AA.Domain.Model;

public abstract class DomainEntity
{
    protected DomainEntity()
    {
        this.Id = Guid.NewGuid().ToString();
    }
    
    public string Id { get; protected set; }
    public string ExternalId { get; protected set; }
}