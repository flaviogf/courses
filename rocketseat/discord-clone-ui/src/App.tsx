import React from "react";
import Layout from "./components/Layout";
import ServerList from "./components/ServerList";
import Style from "./style";

function App() {
  return (
    <>
      <Layout>
        <ServerList />
      </Layout>
      <Style />
    </>
  );
}

export default App;
