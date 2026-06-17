# 1. Bring in the official .NET SDK to compile the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /app

# Copy everything and restore/publish production binaries
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# 2. Build runtime image using the lightweight .NET ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build-env /app/out .

# Render dynamically assigns a port via the PORT environment variable
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "cse325-final-project.dll"]