FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/MobileFoodPermits.Service/MobileFoodPermits.Service.csproj", "src/MobileFoodPermits.Service/"]
RUN dotnet restore "src/MobileFoodPermits.Service/MobileFoodPermits.Service.csproj"
COPY . .
WORKDIR "/src/src/MobileFoodPermits.Service"
RUN dotnet build "MobileFoodPermits.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MobileFoodPermits.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MobileFoodPermits.Service.dll"]