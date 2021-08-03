FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["UpCourse.API/UpCourse.API.csproj", "UpCourse.API/"]
RUN dotnet restore "UpCourse.API/UpCourse.API.csproj"
COPY . .
WORKDIR "/src/UpCourse.API"
RUN dotnet build "UpCourse.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UpCourse.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UpCourse.API.dll"]
