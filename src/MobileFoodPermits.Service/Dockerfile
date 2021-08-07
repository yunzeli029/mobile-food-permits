FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/MobileFoodPermitAPI/MobileFoodPermitAPI.csproj", "src/MobileFoodPermitAPI/"]
RUN dotnet restore "src/MobileFoodPermitAPI/MobileFoodPermitAPI.csproj"
COPY . .
WORKDIR "/src/src/MobileFoodPermitAPI"
RUN dotnet build "MobileFoodPermitAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MobileFoodPermitAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MobileFoodPermitAPI.dll"]