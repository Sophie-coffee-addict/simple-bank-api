# Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ["SimpleBankPaymentsAPI.csproj", "./"]
RUN dotnet restore "SimpleBankPaymentsAPI.csproj"

COPY . .
RUN dotnet build "SimpleBankPaymentsAPI.csproj" -c Release -o /app/build
RUN dotnet publish "SimpleBankPaymentsAPI.csproj" -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SimpleBankPaymentsAPI.dll"]
