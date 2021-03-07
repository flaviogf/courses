FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
COPY ./GameEngine/GameEngine.csproj ./GameEngine/
COPY ./GameEngine.Test/GameEngine.Test.csproj ./GameEngine.Test/
COPY ./GameEngine.sln ./
RUN dotnet restore
COPY . .
