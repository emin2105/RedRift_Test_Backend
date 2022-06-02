#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedRift_Test_Backend.Core/RedRift_Test_Backend.Core.csproj", "RedRift_Test_Backend.Core/"]
RUN dotnet restore "RedRift_Test_Backend.Core/RedRift_Test_Backend.Core.csproj"
COPY . .
WORKDIR "/src/RedRift_Test_Backend.Core"
RUN dotnet build "RedRift_Test_Backend.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedRift_Test_Backend.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedRift_Test_Backend.Core.dll"]