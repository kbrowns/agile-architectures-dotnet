namespace AA.Domain.Model;

public class Product : DomainEntity
{
    protected Product() { /* needed by ef */ }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public decimal Price { get; protected set; }
}