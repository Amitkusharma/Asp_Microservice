#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/BuyerBidService/BuyerBidService.Api/BuyerBidService.Api.csproj", "Services/BuyerBidService/BuyerBidService.Api/"]
COPY ["Services/Framework/FrameWorkApi/FrameWorkApi.csproj", "Services/Framework/FrameWorkApi/"]
RUN dotnet restore "Services/BuyerBidService/BuyerBidService.Api/BuyerBidService.Api.csproj"
COPY . .
WORKDIR "/src/Services/BuyerBidService/BuyerBidService.Api"
RUN dotnet build "BuyerBidService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BuyerBidService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BuyerBidService.Api.dll"]