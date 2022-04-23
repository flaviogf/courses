FROM golang:1.18
WORKDIR /www
RUN apt-get update -y \
    && apt-get install -y curl unzip \
    && curl -Lso /tmp/protoc.zip 'https://github.com/protocolbuffers/protobuf/releases/download/v3.20.1/protoc-3.20.1-linux-x86_64.zip' \
    && unzip -qd /usr/local/protoc /tmp/protoc.zip \
    && go install google.golang.org/protobuf/cmd/protoc-gen-go@latest
ENV PATH=/usr/local/protoc/bin:$PATH
