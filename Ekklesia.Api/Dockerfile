From mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o ./build

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/build/ .

ENTRYPOINT ["dotnet", "Ekklesia.Api.dll"]