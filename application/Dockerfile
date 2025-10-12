FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy all project files
COPY ["application/application.csproj", "application/"]
COPY ["domain/domain.csproj", "domain/"]
COPY ["infra/infra.csproj", "infra/"]
COPY ["service/service.csproj", "service/"]

# Restore dependencies
RUN dotnet restore "application/application.csproj"

# Copy source code
COPY . .

# Build (for development, we don't need to publish)
RUN dotnet build "application/application.csproj" -c Debug --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "application.dll"]