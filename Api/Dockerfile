# STEP 1
# -------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /App

COPY . .

# Restore as distinct layers
RUN dotnet restore ContactManagerApi
# Build and publish a release
RUN dotnet publish ContactManagerApi -c Release -o out

# STEP 2
# -------------------------------------------------------------------
# Build runtime image
# TODO: can change to mcr.microsoft.com/dotnet/runtime:7.0
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as runtime
WORKDIR /App
COPY --from=build /App/out .
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "ContactManagerApi.dll"]