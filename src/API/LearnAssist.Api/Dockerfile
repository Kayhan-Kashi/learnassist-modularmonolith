FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/API/LearnAssist.Api/LearnAssist.Api.csproj", "src/API/LearnAssist.Api/"]
COPY ["src/Modules/Courses/LearnAssist.Modules.Courses.Api/LearnAssist.Courses.Api.csproj", "src/Modules/Courses/LearnAssist.Modules.Courses.Api/"]
RUN dotnet restore "src/API/LearnAssist.Api/LearnAssist.Api.csproj"
COPY . .
WORKDIR "/src/src/API/LearnAssist.Api"
RUN dotnet build "LearnAssist.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LearnAssist.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearnAssist.Api.dll"]
 
