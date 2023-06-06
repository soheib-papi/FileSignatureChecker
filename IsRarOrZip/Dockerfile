FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IsRarOrZip/IsRarOrZip.csproj", "IsRarOrZip/"]
RUN dotnet restore "IsRarOrZip/IsRarOrZip.csproj"
COPY . .
WORKDIR "/src/IsRarOrZip"
RUN dotnet build "IsRarOrZip.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IsRarOrZip.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IsRarOrZip.dll"]
