import { Request, Response } from "express";

export function greeting(request: Request, response: Response) {
  return response.json({ ok: true });
}
