#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["ResourceService", "ResourceService/"]
COPY ["Atos.Core", "Atos.Core/"]

RUN dotnet restore "ResourceService/src/ResourceServiceApi/ResourceServiceApi.csproj"

COPY ResourceService/ .
COPY Atos.Core/ .

WORKDIR "/src/ResourceService/src/ResourceServiceApi/"

RUN dotnet build "ResourceServiceApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResourceServiceApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final

ARG dbpass
ARG dbuser
ARG dbhost
ARG dbport
ARG dbname

ARG mqhost
ARG mqport
ARG mquser
ARG mqpass

ENV DBPASSWORD=$dbpass
ENV DBUSER=$dbuser
ENV DBHOST=$dbhost
ENV DBPORT=$dbport
ENV DBNAME=$dbname

ENV MQUSER=$mquser
ENV MQPASSWORD=$mqpassword
ENV MQHOST=$mqhost
ENV MQPORT=$port

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResourceServiceApi.dll"]