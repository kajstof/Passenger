# Passenger

[Asp.Net Core] Becoming a software developer tutorial

## Adding projects and solution

```sh
# Add projects
dotnet new classlib -o Passenger.Core
dotnet new classlib -o Passenger.Infrastructure
dotnet new webapi -o Passenger.Api
dotnet new nunit -o Passenger.Tests
dotnet new classlib -o Passenger.Tests.EndToEnd
dotnet new sln

# Add projects to solution
dotnet sln add Passenger.Api Passenger.Core Passenger.Infrastructure Passenger.Tests Passenger.Tests.EndToEnd
```