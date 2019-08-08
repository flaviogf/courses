import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import "./App.css";

import Login from "./pages/Login";
import Main from "./pages/Main";

export default function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/" exact component={Login} />
        <Route path="/devs/:id" component={Main} />
      </Switch>
    </BrowserRouter>
  );
}
