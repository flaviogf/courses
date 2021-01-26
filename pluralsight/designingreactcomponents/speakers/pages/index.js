import React from "react";
import Footer from "../components/Footer";
import Header from "../components/Header";
import Menu from "../components/Menu";
import Speakers from "../components/Speakers";
import SpeakerSearchBar from "../components/SpeakerSearchBar";

export default function Index() {
  return (
    <>
      <Header />
      <Menu />
      <SpeakerSearchBar />
      <Speakers />
      <Footer />
      <button className="btn-blue">Don't press</button>
    </>
  );
}
