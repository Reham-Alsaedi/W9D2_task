# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 6001

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["PostService/PostService.csproj", "PostService/"]
RUN dotnet restore "PostService/PostService.csproj"
COPY . .
WORKDIR "/src/PostService"
RUN dotnet build "PostService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PostService.csproj" -c Release -o /app/publish

# Final stage: copy the built app to the base image and run
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PostService.dll"]
