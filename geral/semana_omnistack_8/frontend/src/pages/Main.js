import React from "react";
import "./Main.css";

const devs = [
  {
    _id: "",
    name: "Barry",
    bio: "The fastest man alive.",
    avatar: "https://api.adorable.io/avatars/285/abott@adorable.png"
  },
  {
    _id: "",
    name: "Barry",
    bio: "The fastest man alive.",
    avatar: "https://api.adorable.io/avatars/285/abott@adorable.png"
  }
];

export default function Main() {
  return (
    <div className="main__container">
      <ul>
        {devs.map(dev => (
          <li className="main__card">
            <header className="main__card-header">
              <img className="main__card-img" src={dev.avatar} alt="avatar" />

              <div className="main__card-description">
                <span className="main__card-name">{dev.name}</span>
                <span className="main__card-bio">{dev.bio}</span>
              </div>
            </header>

            <footer className="main__card-footer">
              <button type="button">Like</button>
              <button type="button">Dislike</button>
            </footer>
          </li>
        ))}
      </ul>
    </div>
  );
}
