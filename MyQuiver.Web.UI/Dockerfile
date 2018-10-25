FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50361
EXPOSE 44379

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MyQuiver.Web.UI/MyQuiver.Web.UI.csproj", "MyQuiver.Web.UI/"]
RUN dotnet restore "MyQuiver.Web.UI/MyQuiver.Web.UI.csproj"
COPY . .
WORKDIR "/src/MyQuiver.Web.UI"
RUN dotnet build "MyQuiver.Web.UI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MyQuiver.Web.UI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyQuiver.Web.UI.dll"]