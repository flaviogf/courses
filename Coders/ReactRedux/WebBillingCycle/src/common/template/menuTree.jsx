import React from 'react';

const MenuTree = (props) => (
  <li className="no-padding">
    <ul className="collapsible collapsible-accordion">
      <li>
        <a className="collapsible-header">
          {props.label}
          <i className="material-icons">arrow_drop_down</i>
        </a>
        <div className="collapsible-body">
          <ul>{props.children}</ul>
        </div>
      </li>
    </ul>
  </li>
);

export default MenuTree;
