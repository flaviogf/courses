package main

import (
	"log"
	"net"

	"github.com/flaviogf/using_grpc_with_go/pb"
	"google.golang.org/grpc"
	"google.golang.org/grpc/credentials"
)

func main() {
	lis, err := net.Listen("tcp", ":9000")

	if err != nil {
		log.Fatal(err)
	}

	creds, err := credentials.NewServerTLSFromFile("cert.pem", "key.pem")

	if err != nil {
		log.Fatal(err)
	}

	s := grpc.NewServer(grpc.Creds(creds))

	pb.RegisterEmployeeServiceServer(s, new(employeeService))

	log.Printf("Listening to: %v\n", lis.Addr())

	s.Serve(lis)
}

type employeeService struct {
	pb.UnimplementedEmployeeServiceServer
}

func (e *employeeService) GetAll(r *pb.GetAllRequest, s pb.EmployeeService_GetAllServer) error {
	employees := []*pb.EmployeeResponse{
		{Id: 1, BadgeNumber: 1, FirstName: "Frank", LastName: "Castle"},
		{Id: 2, BadgeNumber: 2, FirstName: "Peter", LastName: "Parker"},
	}

	for _, employee := range employees {
		s.Send(employee)
	}

	return nil
}
