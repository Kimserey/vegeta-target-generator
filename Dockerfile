FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY src/VegetaTargetGeneratorCS/*.csproj ./
RUN dotnet restore
COPY src/VegetaTargetGeneratorCS/ ./
RUN dotnet publish -c Release -o out

COPY ./benchmark.sh ./out

# Setup application runtime
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .

# Install Vegeta
ENV VEGETA_VERSION 12.1.0
ADD https://github.com/tsenart/vegeta/releases/download/cli%2Fv${VEGETA_VERSION}/vegeta-${VEGETA_VERSION}-linux-amd64.tar.gz /tmp/vegeta.tar.gz
RUN cd /bin \
	&& tar -zxvf /tmp/vegeta.tar.gz \
	&& chmod +x /bin/vegeta \
	&& rm /tmp/vegeta.tar.gz

# Folder for Vegeta results
RUN mkdir results

CMD [ "bash", "benchmark.sh" ]