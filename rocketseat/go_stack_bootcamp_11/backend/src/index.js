const debug = require("debug")("backend");
const express = require("express");
const { v4: uuid } = require("uuid");

function log(req, res, next) {
  const { method, url } = req;

  debug(`${method} |> ${url}`);

  next();
}

const app = express();

app.use(express.json());
app.use(log);

const projects = [];

app.post("/projects", (req, res) => {
  const { title, description } = req.body;

  const id = uuid();

  const project = {
    id,
    title,
    description,
  };

  projects.push(project);

  return res.json(project);
});

app.get("/projects", (req, res) => {
  return res.json(projects);
});

app.put("/projects/:id", (req, res) => {
  const { id } = req.params;

  const { title, description } = req.body;

  const index = projects.findIndex((it) => it.id === id);

  if (index < 0) {
    return res.status(404).json({ error: "Project does not exist" });
  }

  const project = {
    id,
    title,
    description,
  };

  projects[index] = project;

  return res.json(project);
});

app.delete("/projects/:id", (req, res) => {
  const { id } = req.params;

  const index = projects.findIndex((it) => it.id === id);

  if (index < 0) {
    return res.status(404).json({ error: "Project does not exist" });
  }

  const [project] = projects.splice(index, 1);

  return res.json(project);
});

app.listen(3333, () => debug("🚀 It is running"));
