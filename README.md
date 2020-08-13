# Atlas (Beta)

![.NET Core](https://github.com/lucabriguglia/Atlas/workflows/.NET%20Core/badge.svg)

A forum software built with ASP.NET Core Blazor WebAssembly.

**Official Website**: [Atlas](https://atlas-blazor.azurewebsites.net/)

**Documentation**: [Atlas Wiki](https://lucabriguglia.github.io/Atlas)

![Forums Admin](docs/assets/img/admin-forums.png)

## Technology

- Blazor WebAssembly 3.2.0
- Entity Framework Core 3.1
- SQL Server (more to come)

## Features

- Themes
- Multi language
- Granular permissions
- Markdown editor
- You can use your own ASP.NET Identity

## Run on local

- Clone the repository
- Run the **Atlas.Server** project
- Database and default data will be created automatically
- Login with any of the following accounts:
  - **Admin User**: admin@default.com / !P455w0rd?
  - **Moderator User**: moderator@default.com / !P455w0rd?
  - **Normal User**: user@default.com / !P455w0rd?

**Note**: Please delete any databases previously created if you pull new versions. It's still a beta and some breaking changes might occur between commits.
