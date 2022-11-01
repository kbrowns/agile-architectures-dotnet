namespace AA.Domain.Model;

public class Order : DomainEntity
{
    protected Order() { /* needed by ef */ }

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public ICollection<OrderItem> Items { get; protected set; } = new List<OrderItem>();
    public Customer Customer { get; protected set; }
}