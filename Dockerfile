FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# Copy solution, restore and build
COPY . ./
RUN dotnet publish HomematicCore.Manager.Web -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "HomematicCore.Manager.Web.dll"]

EXPOSE 80