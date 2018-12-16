import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import MenuItem from './menuItem';
import MenuTree from './menuTree';

export default class Menu extends Component {
  componentDidMount() {
    $('.button-collapse').sideNav();
  }

  render() {
    return (
      <nav className="blue">
        <div className="nav-wrapper">
          <Link to="/" className="brand-logo center">
            My money
          </Link>
          <ul id="slide-out" className="side-nav">
            <MenuItem path="/" label="Dashboard" />
            <MenuTree label="Cadastro">
              <MenuItem path="/billingCycles" label="Ciclos de Pagamento" />
            </MenuTree>
          </ul>
          <a
            href="#"
            data-activates="slide-out"
            className="button-collapse show-on-large"
          >
            <i className="material-icons">menu</i>
          </a>
        </div>
      </nav>
    );
  }
}
