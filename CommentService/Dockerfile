# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 6002

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CommentService/CommentService.csproj", "CommentService/"]
RUN dotnet restore "CommentService/CommentService.csproj"
COPY . .
WORKDIR "/src/CommentService"
RUN dotnet build "CommentService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommentService.csproj" -c Release -o /app/publish

# Final stage: copy the built app to the base image and run
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommentService.dll"]
