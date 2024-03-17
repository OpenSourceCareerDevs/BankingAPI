FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /build
EXPOSE 80
COPY BankingAPIs .
WORKDIR /build/BankingAPIs

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS runtime
WORKDIR /app
COPY --from=build /build/BankingAPIs/out ./


ENTRYPOINT ["dotnet", "BankingAPIs"]
