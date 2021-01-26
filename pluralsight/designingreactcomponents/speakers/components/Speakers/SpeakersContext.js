import React, { useContext } from "react";

const Context = React.createContext([]);

export default function SpeakersContext() {
  const speakers = [
    {
      imageSrc: "https://via.placeholder.com/150",
      name: "Vladimir Khorikov",
    },
    {
      imageSrc: "https://via.placeholder.com/150",
      name: "Kevin Dockx",
    },
    {
      imageSrc: "https://via.placeholder.com/150",
      name: "Cory House",
    },
  ];

  return (
    <Context.Provider value={speakers}>
      <Speakers />
    </Context.Provider>
  );
}

function Speakers() {
  const speakers = useContext(Context);

  return speakers.map(({ imageSrc, name }) => (
    <img src={imageSrc} alt={name} key={name} />
  ));
}
