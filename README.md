# SportsStore Solution

This repository contains the source code for the **SportsStore** application, as featured in the book "Pro ASP.NET Core 6" by Adam Freeman.

## Overview

SportsStore is a sample e-commerce web application built using **ASP.NET Core 6**. It demonstrates key concepts such as:

- Entity Framework Core for data access
- Dependency Injection
- Razor Pages and MVC
- Blazor components
- Custom Tag Helpers
- Unit testing with xUnit and Moq

The solution is organized into the following projects:

- **SportsStore**: The main web application, including models, data access, UI components, and business logic.
- **SportsStore.Test**: Unit tests for the application, using xUnit and Moq.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Visual Studio 2022 or later

## Getting Started

1. **Clone the repository:** git clone https://github.com/<your-username>/SportsStore.git

2. **Open the solution in Visual Studio 2022.**

3. **Restore NuGet packages** if not done automatically.

4. **Update the database connection string** in `appsettings.json` as needed.

5. **Run database migrations** (if applicable): dotnet ef database update --project SportsStore

6. **Build and run the application.**

## Testing

Unit tests are located in the `SportsStore.Test` project. To run tests: dotnet test SportsStore.Test

## Structure

- `SportsStore/`  
  Main web application (ASP.NET Core 6, Razor Pages, Blazor, MVC)
- `SportsStore.Test/`  
  Unit tests (xUnit, Moq)

## License

This repository is for educational purposes and is based on the code samples from the book **Pro ASP.NET Core 6** by Adam Freeman.

