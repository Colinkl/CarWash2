#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarWash2/CarWash2.csproj", "CarWash2/"]
RUN dotnet restore "CarWash2/CarWash2.csproj"
COPY . .
WORKDIR "/src/CarWash2"
RUN dotnet build "CarWash2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarWash2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarWash2.dll"]