FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AA.Tools/AA.Tools.csproj", "AA.Tools/"]
RUN dotnet restore "AA.Tools/AA.Tools.csproj"
COPY . .
WORKDIR "/src/AA.Tools"
RUN dotnet build "AA.Tools.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AA.Tools.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AA.Tools.dll"]
