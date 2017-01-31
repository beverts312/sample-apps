FROM microsoft/dotnet:latest

COPY src /app

WORKDIR /app

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

EXPOSE 80/tcp

CMD ["dotnet", "run", "--server.urls", "http://*"]
