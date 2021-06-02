```sh
go install google.golang.org/protobuf/cmd/protoc-gen-go@v1.26
go install google.golang.org/grpc/cmd/protoc-gen-go-grpc@v1.1
```

```sh
protoc --go_out=./pb --go_opt=module=github.com/flaviogf/using_grpc_with_go/pb --go-grpc_out=./pb --go-grpc_opt=module=github.com/flaviogf/using_grpc_with_go/pb ./pb/messages.proto
```

```sh
go run $(go env GOROOT)/src/crypto/tls/generate_cert.go -host localhost
```
