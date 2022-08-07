#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BackBiblioMeta/BackBiblioMeta.csproj", "BackBiblioMeta/"]
RUN dotnet restore "BackBiblioMeta/BackBiblioMeta.csproj"
COPY . .
WORKDIR "/src/BackBiblioMeta"
RUN dotnet build "BackBiblioMeta.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackBiblioMeta.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackBiblioMeta.dll"]