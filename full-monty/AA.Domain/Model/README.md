# Design Conventions
* Domain state is to be protected (EF play nicely here) - take care in marking access appropriately - e.g. immutable properties should not have public setters
* Similarly, give thought to constructors - what is required to construct this?  Your constructor should advertise the core relationships between entities - e.g. can Order cannot exist without a Customer.  Order's constructor should probably accept an Order argument
* Similarly, methods on your entities should represent what the thing can "do"... but BEWARE.  This gets tricky in practice in the real world.  Yes, things can be passed to the entity method (helpers), but depedencies can get weird quickly.  In practice, methods should generally be scoped at what can be done with the state of the object.  More complex behaviors will almost always be outside the entity.

# Notable Patterns
### EntityMaps
This is borrowed from NHibernate and FluentNHibernate.  EF Core doc calls for defining mappings in your DbContext's OnModelCreating method.  This gets very unwieldy with many entities and is a common source of merge conflict help.  Best to break this out to separate classes.  This pattern calls for mapping defined in separate classes and then discovered and loaded automatically via reflection from OnModelCreating.

