FROM microsoft/aspnetcore:2.0.0

WORKDIR /app
COPY /publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Elo.dll