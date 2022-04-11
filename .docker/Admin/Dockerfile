FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /build

COPY ../../*.sln .
COPY ../../src ./src
RUN dotnet restore

COPY ../../src/Admin/Api ./src/app
WORKDIR /src/app
RUN dotnet publish -c release -o ./ --no-restore --no-self-contained

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT [ "dotnet", "Api.dll" ]