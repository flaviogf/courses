import React from "react";

const maxNumberOfSpeakers = 3;

export default withData(maxNumberOfSpeakers)(SpeakersHOC);

function withData(maxNumberOfSpeakers) {
  return (Component) => () => {
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

    return <Component speakers={speakers.slice(0, maxNumberOfSpeakers)} />;
  };
}

function SpeakersHOC({ speakers }) {
  return speakers.map(({ imageSrc, name }) => (
    <img src={imageSrc} alt={name} key={name} />
  ));
}
