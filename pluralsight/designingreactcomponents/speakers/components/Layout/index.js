import React from "react";
import Footer from "../Footer";
import Header from "../Header";
import Menu from "../Menu";

export default function Layout({ children }) {
  return (
    <div className="mx-4 my-3">
      <Header />
      <Menu />
      {children}
      <Footer />
    </div>
  );
}
