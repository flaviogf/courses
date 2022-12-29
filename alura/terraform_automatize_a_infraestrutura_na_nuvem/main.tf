terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 4.0"
    }
  }
}

provider "aws" {
  region = "us-east-1"
}

resource "aws_instance" "dev" {
  count           = 3
  ami             = "ami-0574da719dca65348"
  instance_type   = "t2.micro"
  key_name        = "terraform-aws"
  security_groups = ["sg-0dbb8840ebbcd0c72"]

  tags = {
    Name = "dev-${count.index}"
  }
}

resource "aws_security_group" "allow_ssh" {
  name = "allow_ssh"

  ingress {
    from_port = 22
    to_port   = 22
    protocol  = "tcp"
  }
}
