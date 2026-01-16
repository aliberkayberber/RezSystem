# RezSystem

A .NET 8 Web API providing authentication and user management features. The codebase is organized into layered projects (WebApi, Business, Data) and includes DTOs and service abstractions for user operations.

## Contents
- `RezSystem.WebApi` — ASP.NET Core Web API entry (controllers, models like `RezSystem.WebApi.Models.LoginRequest`).
- `RezSystem.Business` — business logic, DTOs (e.g. `RezSystem.Business.Operations.User.Dtos.UserInfoDto`, `LoginUserDto`), service messages (`RezSystem.Business.Types.ServiceMessage`), and user manager (`RezSystem.Business.Operations.User.UserManager`, `IUserService`).
- `RezSystem.Data` — persistence layer and entities (e.g. `RezSystem.Data.Entities.UserEntity`).

## Requirements
- .NET 8 SDK
- Visual Studio 2022 (latest update recommended)
- Optional: a database configured via `appsettings.json` or your secret store if the project requires persistence.

## Quick start (Visual Studio)
1. Clone the repo:
   - git clone https://github.com/aliberkayberber/RezSystem
2. Open `RezSystem.sln` in Visual Studio 2022.
3. Set `RezSystem.WebApi` as the startup project.
4. Build and run:
   - Use __Build Solution__ to compile.
   - Use __Debug > Start Debugging__ or __Debug > Start Without Debugging__ to run the API.

## Quick start (CLI)
From repository root: