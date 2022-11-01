using AA.Domain;
using AA.Domain.Model;

namespace AA.Tests;

public class CustomerPersistenceTests : BaseDatabaseTests
{
    [Fact]
    public void Test1()
    {
        var db = this.CreateDatabase();

        db.Customers.Add(new Customer("test1", "test1@test.com", "1"));
        db.Customers.Add(new Customer("test2", "test2@test.com", "2"));
        db.Customers.Add(new Customer("test3", "test3@test.com", "3"));

        db.SaveChanges();
        
        var customers = db.Customers.ToList();
        Assert.NotNull(customers);
    }
}