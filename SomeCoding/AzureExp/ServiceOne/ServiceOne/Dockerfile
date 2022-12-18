FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ServiceOne/ServiceOne.csproj", "ServiceOne/"]
RUN dotnet restore "ServiceOne/ServiceOne.csproj"
COPY . .
WORKDIR "/src/ServiceOne"
RUN dotnet build "ServiceOne.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceOne.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceOne.dll"]
