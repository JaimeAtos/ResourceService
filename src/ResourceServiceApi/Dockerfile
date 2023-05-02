#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ARG dbpass
ARG dbuser
ARG dbhost
ARG dbport
ARG dbname

ENV DBPASSWORD=$dbpass
ENV DBUSER=$dbuser
ENV DBHOST=$dbhost
ENV DBPORT=$dbport
ENV DBNAME=$dbname

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ResourceWebApi/ResourceWebApi.csproj", "ResourceWebApi/"]
RUN dotnet restore "ResourceWebApi/ResourceWebApi.csproj"
COPY . .
WORKDIR "/src/ResourceWebApi"
RUN dotnet build "ResourceWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResourceWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResourceWebApi.dll"]