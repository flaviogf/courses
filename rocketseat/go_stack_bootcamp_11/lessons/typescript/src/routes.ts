import { Request, Response } from "express";
import { createUser } from "./services/CreateUser";

export function greeting(request: Request, response: Response) {
  const user = createUser({ email: "frank@email.com", password: "test123" });

  return response.json({ data: user });
}
