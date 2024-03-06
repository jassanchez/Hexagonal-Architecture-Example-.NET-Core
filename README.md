# Hexagonal Architechture Example .NET Core 8

This project is an example of Hexagonal Architecture in a API REST with .NET Core using:
- Dapper
- Automapper
- JWT
- Cors
- Swagger
- MSTest
- Dockerfile for container
and more ...

## Use

For use this project, you need [Northwind Database](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs) for SQL Server
And create this table in Nortwind

``` SQL
CREATE TABLE Users(
  UserId INT PRIMARY KEY IDENTITY(1,1),
  Firstname VARCHAR(50),
  Lastname VARCHAR(50),
  Username VARCHAR(10),
  Password VARCHAR(20),
  Token VARCHAR(MAX)
);
```

*Note: Create the users by your own in the database, Endpoints to create user isn't already, this is for you can authenthicate with Bearer JWT*

This project is currently in constant update.

Be Yourself! :)
