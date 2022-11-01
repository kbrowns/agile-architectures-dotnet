namespace AA.Domain.Model;

public class OrderItem : DomainEntity
{
    protected OrderItem() { /* needed by ef */ }
    
    public OrderItem(Product product, Order order)
    {
        this.Product = product;
        this.Order = order;
    }
    
    public Product Product { get; protected set; }
    public decimal Discount { get; protected set; }
    public decimal Tax { get; protected set; }
    public decimal Amount { get; protected set; }
    
    public Order Order { get; protected set; }
}