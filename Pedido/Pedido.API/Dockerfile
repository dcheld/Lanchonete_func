#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Pedido/Pedido.API/Pedido.API.csproj", "Pedido/Pedido.API/"]
COPY ["Pedido/Pedido.Dominio/Pedido.Dominio.csproj", "Pedido/Pedido.Dominio/"]
RUN dotnet restore "Pedido/Pedido.API/Pedido.API.csproj"
COPY . .
WORKDIR "/src/Pedido/Pedido.API"
RUN dotnet build "Pedido.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pedido.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pedido.API.dll"]