# Temel imajı belirleyin (ASP.NET Core runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# .NET SDK'yı kullanarak derleme işlemi
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Techofest-Team-Website/Techofest-Team-Website.csproj", "Techofest-Team-Website/"]
RUN dotnet restore "Techofest-Team-Website/Techofest-Team-Website.csproj"
COPY . .
WORKDIR "/src/Techofest-Team-Website"
RUN dotnet build "./Techofest-Team-Website.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Yayınlama aşaması
FROM build AS publish
RUN dotnet publish "./Techofest-Team-Website.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final aşaması, uygulamayı çalıştıracak konteynerin oluşturulması
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Techofest-Team-Website.dll"]
