import React from "react";
import axios from "axios";
import "./App.css";

export default class App extends React.Component {
  state = {
    profiles: [],
  };

  addProfile = (profile) => {
    this.setState((prevState) => ({
      profiles: [...prevState.profiles, profile],
    }));
  };

  render() {
    return (
      <main className="App__container">
        <Form onSubmit={this.addProfile} />
        <CardList profiles={this.state.profiles} />
      </main>
    );
  }
}

class Form extends React.Component {
  state = {
    userName: "",
  };

  handleSubmit = async (event) => {
    event.preventDefault();

    const response = await axios.get(
      `https://api.github.com/users/${this.state.userName}`
    );

    this.props.onSubmit(response.data);

    this.setState({ userName: "" });
  };

  render() {
    return (
      <form onSubmit={this.handleSubmit} className="Form__container">
        <input
          className="Form__input"
          placeholder="Enter an username"
          value={this.state.userName}
          onChange={(event) => this.setState({ userName: event.target.value })}
        />
      </form>
    );
  }
}

class CardList extends React.Component {
  render() {
    return this.props.profiles.map((it) => (
      <Card key={String(it.id)} {...it} />
    ));
  }
}

class Card extends React.Component {
  render() {
    const profile = this.props;

    return (
      <div className="Card__container">
        <img
          className="Card__image"
          src={profile.avatar_url}
          alt={profile.name}
        />
        <div className="Card__summary">
          <span className="Card__title">{profile.name}</span>
          <span className="Card__subtitle">{profile.login}</span>
        </div>
      </div>
    );
  }
}
