# build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .
RUN --mount=type=secret,id=gh_packages_token \
    dotnet nuget add source "https://nuget.pkg.github.com/pankunik/index.json" \
    --name "github" \
    --username "USERNAME" \
    --password "$(cat /run/secrets/gh_packages_token)" \
    --store-password-in-clear-text && \
    dotnet restore src/DoIt.Api/DoIt.Api.csproj

RUN dotnet publish src/DoIt.Api/DoIt.Api.csproj -c Release -o /app/publish

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DoIt.Api.dll"]