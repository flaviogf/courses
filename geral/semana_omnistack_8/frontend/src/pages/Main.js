import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import "./Main.css";
import like from "../assets/like.svg";
import dislike from "../assets/dislike.svg";
import logo from "../assets/logo.svg";
import api from "../services/api";

export default function Main({ match }) {
  const [devs, setDevs] = useState([]);

  useEffect(() => {
    async function listDevs() {
      const response = await api.get("/devs", {
        headers: {
          user: match.params.id
        }
      });

      setDevs(response.data);
    }

    listDevs();
  }, [match.params.id]);

  function clickDislike({ _id }) {
    return async () => {
      const response = await api.post(`/devs/${_id}/dislike`, null, {
        headers: {
          user: match.params.id
        }
      });

      setDevs(devs.filter(dev => dev._id != _id));
    };
  }

  function clickLike({ _id }) {
    return async () => {
      const response = await api.post(`/devs/${_id}/like`, null, {
        headers: {
          user: match.params.id
        }
      });

      setDevs(devs.filter(dev => dev._id != _id));
    };
  }

  return (
    <div className="main__container">
      <Link to="/">
        <img src={logo} alt="logo" />
      </Link>

      {devs.length ? (
        <ul className="main__dev-list">
          {devs.map(dev => (
            <li className="main__dev-card" key={dev._id}>
              <img src={dev.avatar} alt="avatar" />

              <footer>
                <span className="main__dev-name">{dev.name}</span>
                <span className="main__dev-bio">{dev.bio}</span>
              </footer>

              <div className="main__dev-buttons">
                <button type="button">
                  <img src={dislike} alt="like" onClick={clickDislike(dev)} />
                </button>
                <button type="button">
                  <img src={like} alt="dislike" onClick={clickLike(dev)} />
                </button>
              </div>
            </li>
          ))}
        </ul>
      ) : (
        <span className="main__dev-list-empty">Acabou :(</span>
      )}
    </div>
  );
}
