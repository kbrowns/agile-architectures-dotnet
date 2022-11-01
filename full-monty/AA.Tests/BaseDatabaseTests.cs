using AA.Domain;

namespace AA.Tests;

public abstract class BaseDatabaseTests
{
    static BaseDatabaseTests()
    {
        // don't need to keep this instance, but do need an instance to ensure the .db file is created
        var db = new Database();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
    }

    protected Database CreateDatabase()
    {
        return new Database();
    }
}