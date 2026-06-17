
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY . .

RUN dotnet restore Server/TransportServer/TransportServer.csproj

RUN dotnet publish \
    Server/TransportServer/TransportServer.csproj \
    -c Release \
    -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "TransportServer.dll"]