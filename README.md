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

# Add references
dotnet add Passenger.Infrastructure reference Passenger.Core
dotnet add Passenger.Api reference Passenger.Infrastructure
dotnet add Passenger.Test reference Passenger.Core Passenger.Infrastructure

# Add NuGet packages
dotnet add Passenger.Tests package FluentAssertions     # --version 5.4.2
dotnet add Passenger.Tests package Moq                  # --version 4.10.0
```