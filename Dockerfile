# Use the .NET 9 SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and projects
COPY ProjectA.sln . 
COPY API/API.csproj API/
COPY API.Tests/API.Tests.csproj API.Tests/
COPY Application/Application.csproj Application/
COPY Application.Tests/Application.Tests.csproj Application.Tests/
COPY Core/Core.csproj Core/
COPY Infrastructure/Infrastructure.csproj Infrastructure/

# Restore dependencies
RUN dotnet restore

# Copy all source code
COPY . .

# Build and publish the ConsoleApp
WORKDIR /src/API
RUN dotnet publish -c Release -o /app/publish

# Use the .NET 9 runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5000

# Set the entry point
ENTRYPOINT ["dotnet", "API.dll"]
