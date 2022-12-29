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
  count         = 3
  ami           = "ami-0574da719dca65348"
  instance_type = "t2.micro"
  tags = {
    Name = "dev-${count.index}"
  }
}
