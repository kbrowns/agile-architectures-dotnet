# Notable Stuff

* Database.cs is the starting point for EF Core - this is the DbContext
* Model/ has all of the entities and their mappings defined in individual files
* You can run the unit tests and a .db file will be created in the bin dir - there you can see the EF exported schema
* Have a look at Services/ to see how this works.  These are not wired up to anything yet.  Controllers would be a thin layer invoking these, but that's not there yet

# 3rd Parties
* EFCore.NamingConventions is what gives us `snake_case_naming` tables, columns, etc.
