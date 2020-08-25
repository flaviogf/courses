import express from "express";
import { greeting } from "./routes";

const app = express();

app.get("/", greeting);

app.listen(3333, () => console.log("🚀 It is running on port 3333"));
