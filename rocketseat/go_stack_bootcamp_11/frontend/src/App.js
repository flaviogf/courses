import React, { useState, useEffect } from "react";

import Header from "./components/Header";
import api from "./services/api";

import "./App.css";

function App() {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    api.get("/projects").then((response) => setProjects(response.data));
  }, []);

  function addProject() {}

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
