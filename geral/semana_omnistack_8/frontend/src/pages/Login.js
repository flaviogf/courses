import React, { useState } from "react";

import "./Login.css";

import api from "../services/api";

export default function Login({ history }) {
  const [user, setUser] = useState();

  async function signIn(e) {
    e.preventDefault();

    const response = await api.post("/devs", {
      login: user
    });

    history.push(`/devs/${response.data._id}`);
  }

  return (
    <div className="login__container">
      <form className="login__form" onSubmit={signIn}>
        <input
          className="login__input"
          placeholder="Username"
          onChange={e => setUser(e.target.value)}
        />
        <button className="login__button" type="submit">
          Sign In
        </button>
      </form>
    </div>
  );
}
