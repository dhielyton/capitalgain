#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CapitalGain.ConsoleApp/CapitalGain.ConsoleApp.csproj", "CapitalGain.ConsoleApp/"]
COPY ["CapitalGain.Application/CapitalGain.Application.csproj", "CapitalGain.Application/"]
COPY ["CapitalGain.Domain/CapitalGain.Domain.csproj", "CapitalGain.Domain/"]
RUN dotnet restore "CapitalGain.ConsoleApp/CapitalGain.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/CapitalGain.ConsoleApp"
RUN dotnet build "CapitalGain.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CapitalGain.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CapitalGain.ConsoleApp.dll"]