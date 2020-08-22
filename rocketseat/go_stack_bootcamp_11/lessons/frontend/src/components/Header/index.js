import React from "react";

function Header({ children, title }) {
  return (
    <header>
      <h1>{title}</h1>
      {children}
    </header>
  );
}

export default Header;
