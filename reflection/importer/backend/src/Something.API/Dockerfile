#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Something.API/Something.API.csproj", "src/Something.API/"]
COPY ["src/Something.Infra.CrossCutting.IoC/Something.Infra.CrossCutting.IoC.csproj", "src/Something.Infra.CrossCutting.IoC/"]
COPY ["src/Something.Application/Something.Application.csproj", "src/Something.Application/"]
COPY ["src/Core.Application/Core.Application.csproj", "src/Core.Application/"]
COPY ["src/Core.Domain/Core.Domain.csproj", "src/Core.Domain/"]
COPY ["src/Something.Domain/Something.Domain.csproj", "src/Something.Domain/"]
COPY ["src/Something.Infra.Data/Something.Infra.Data.csproj", "src/Something.Infra.Data/"]
COPY ["src/Core.Infra.Data/Core.Infra.Data.csproj", "src/Core.Infra.Data/"]
COPY ["src/Core.API/Core.API.csproj", "src/Core.API/"]
RUN dotnet restore "src/Something.API/Something.API.csproj"
COPY . .
WORKDIR "/src/src/Something.API"
RUN dotnet build "Something.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Something.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Something.API.dll"]