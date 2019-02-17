import React, { Component } from 'react';
import { Link } from 'react-router-dom';

class MenuItem extends Component {
  onClick() {
    $('.button-collapse').sideNav('hide');
  }

  render() {
    return (
      <li>
        <Link to={this.props.path} onClick={this.onClick}>
          {this.props.label}
        </Link>
      </li>
    );
  }
}

export default MenuItem;
