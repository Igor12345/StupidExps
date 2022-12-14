FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleTasksExperiments/SimpleTasksExperiments.csproj", "SimpleTasksExperiments/"]
RUN dotnet restore "SimpleTasksExperiments/SimpleTasksExperiments.csproj"
COPY . .
WORKDIR "/src/SimpleTasksExperiments"
RUN dotnet build "SimpleTasksExperiments.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleTasksExperiments.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleTasksExperiments.dll"]
