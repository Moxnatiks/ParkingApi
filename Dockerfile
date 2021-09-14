#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:4000
EXPOSE 80
EXPOSE 443
EXPOSE 4000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
COPY ["ParkingApi.csproj", "."]
RUN dotnet restore "./ParkingApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ParkingApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParkingApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParkingApi.dll"]