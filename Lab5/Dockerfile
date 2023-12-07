FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Lab5/Lab5.csproj", "Lab5/"]
RUN dotnet restore "Lab5/Lab5.csproj"
COPY . .
WORKDIR "/src/Lab5"
RUN dotnet build "Lab5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lab5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab5.dll"]
