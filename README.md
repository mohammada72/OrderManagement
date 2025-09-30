# Sample Order Management Application

This repository contains a sample Order Management application demonstrating a clean architecture approach with Domain-Driven Design (DDD) principles.

## Solution Overview

The solution includes two executable projects:

- **Web API project** for handling order management requests.
- **.NET Aspire project** (work in progress).

### Prerequisites

- A running SQL Server instance is required.
- If you have experience with ASP.NET projects, configuring the connection strings and other settings in the `appsettings.json` file will be straightforward.

### Building and Running

- You can build the projects using the `.NET CLI` or `MSBuild`.
- A Dockerfile is included for containerization — allowing you to build images and run the app in Docker containers.
- The .NET Aspire project will be fully supported soon.

## Architecture

- The application follows **Clean Architecture** principles.
- The **Domain Layer** implements core business logic and some DDD concepts.
- Currently, only the Domain Layer contains unit tests; test coverage should be expanded.
- **Entity Framework Core** is u
