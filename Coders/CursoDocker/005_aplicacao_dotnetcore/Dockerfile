FROM microsoft/dotnet

WORKDIR /app

COPY ./App .

RUN dotnet restore

ENTRYPOINT ["dotnet"]
CMD ["run"]
