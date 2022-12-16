FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BenchmarksExperiments/BenchmarksExperiments.csproj", "BenchmarksExperiments/"]
RUN dotnet restore "BenchmarksExperiments/BenchmarksExperiments.csproj"
COPY . .
WORKDIR "/src/BenchmarksExperiments"
RUN dotnet build "BenchmarksExperiments.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BenchmarksExperiments.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BenchmarksExperiments.dll"]
