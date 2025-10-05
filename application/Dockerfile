FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["myfinance-web-dotnet.csproj", "."]
RUN dotnet restore "./myfinance-web-dotnet.csproj"

COPY . .

RUN dotnet publish "myfinance-web-dotnet.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "myfinance-web-dotnet.dll"]