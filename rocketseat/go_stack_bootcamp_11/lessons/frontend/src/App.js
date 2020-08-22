import React, { useState, useEffect } from "react";

import Header from "./components/Header";
import api from "./services/api";

import "./App.css";

function App() {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    api.get("/projects").then((response) => setProjects(response.data));
  }, []);

  function addProject() {
    const now = Date.now();

    const project = {
      title: `Something to do at ${now}`,
      description: `I believe I will have something to do at ${now} at least I expect that will be true`,
    };

    api
      .post("/projects", project)
      .then((response) => setProjects((prev) => [...prev, response.data]));
  }

  return (
    <>
      <Header title="Projects">
        <ul>
          {projects.map((it) => (
            <li key={it.id}>{it.title}</li>
          ))}
        </ul>
      </Header>
      <button onClick={addProject}>Add</button>
    </>
  );
}

export default App;
