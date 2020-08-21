import React, { useState } from "react";

import Header from "./components/Header";

function App() {
  const [projects, setProjects] = useState(["Study English", "Study Go Stack"]);

  function addProject() {
    const project = `Project ${Date.now()}`;

    setProjects([...projects, project]);
  }

  return (
    <>
      <Header title="Projects">
        <ul>
          {projects.map((it) => (
            <li key={it}>{it}</li>
          ))}
        </ul>
      </Header>
      <button onClick={addProject}>Add</button>
    </>
  );
}

export default App;
