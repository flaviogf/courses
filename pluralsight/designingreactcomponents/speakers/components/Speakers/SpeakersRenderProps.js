import React from "react";

export default function Speakers({ speakers }) {
  return (
    <SpeakersRenderProps>
      {(speakers) =>
        speakers.map(({ imageSrc, name }) => (
          <img src={imageSrc} alt={name} key={name} />
        ))
      }
    </SpeakersRenderProps>
  );
}

function SpeakersRenderProps(props) {
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

  return props.children(speakers);
}
