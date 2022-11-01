using Microsoft.EntityFrameworkCore;

namespace AA.Domain.Model;

public interface IEntityMapping
{
    void Map(ModelBuilder modelBuilder);
}