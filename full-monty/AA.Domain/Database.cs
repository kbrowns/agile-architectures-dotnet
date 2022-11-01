using System.Reflection;
using AA.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AA.Domain;

public class Database : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=aa-full-monty.db")
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var mappingTypes = typeof(Database).Assembly.GetConcreteTypesExtending<IEntityMapping>();
        var mappings = mappingTypes.Select(Activator.CreateInstance).Cast<IEntityMapping>();

        foreach (var mapping in mappings)
        {
            mapping?.Map(modelBuilder);
        }
    }
}