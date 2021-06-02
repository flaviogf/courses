package main

import (
	"context"
	"fmt"
	"io"
	"log"

	"github.com/flaviogf/using_grpc_with_go/pb"
	"google.golang.org/grpc"
	"google.golang.org/grpc/credentials"
)

func main() {
	creds, err := credentials.NewClientTLSFromFile("cert.pem", "")

	if err != nil {
		log.Fatal(err)
	}

	conn, err := grpc.Dial("localhost:9000", grpc.WithTransportCredentials(creds))

	if err != nil {
		log.Fatal(err)
	}

	defer conn.Close()

	c := pb.NewEmployeeServiceClient(conn)

	resp, err := c.GetAll(context.Background(), &pb.GetAllRequest{})

	if err != nil {
		log.Fatal(err)
	}

	for {
		employee, err := resp.Recv()

		if err == io.EOF {
			break
		}

		if err != nil {
			log.Fatal(err)
		}

		fmt.Println(employee.GetFirstName())
	}
}
