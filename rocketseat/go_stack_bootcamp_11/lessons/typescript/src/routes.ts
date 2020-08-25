import { Request, Response } from "express";
import { createUser } from "./services/CreateUser";

export function greeting(request: Request, response: Response) {
  const user = createUser({
    email: "frank@email.com",
    password: "test123",
    techs: [
      "React.js",
      "React Native",
      { title: "Node.js", experience: 100 },
      { title: "C#", experience: 100 },
    ],
  });

  return response.json({ data: user });
}
