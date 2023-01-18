#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WebApi/TestQuala.WebApi/TestQuala.WebApi.csproj", "src/WebApi/TestQuala.WebApi/"]
RUN dotnet restore "src/WebApi/TestQuala.WebApi/TestQuala.WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi/TestQuala.WebApi"
RUN dotnet build "TestQuala.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestQuala.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestQuala.WebApi.dll"]