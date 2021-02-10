import React from "react";
import Speaker from "../Speaker";
import SpeakersSearchBar from "../SpeakersSearchBar";

export default function Speakers() {
  return (
    <SpeakersRenderProps>
      {(speakers) => (
        <>
          <SpeakersSearchBar />

          <div className="grid md:grid-cols-2 lg:grid-cols-3 grid-cols-1 gap-12">
            {speakers.map(
              ({ id, firstName, lastName, bio, avatar, isFavorite }) => (
                <Speaker
                  key={String(id)}
                  firstName={firstName}
                  lastName={lastName}
                  bio={bio}
                  avatar={avatar}
                  isFavorite={isFavorite}
                />
              )
            )}
          </div>
        </>
      )}
    </SpeakersRenderProps>
  );
}

function SpeakersRenderProps(props) {
  const speakers = [
    {
      id: 1,
      firstName: "Vladimir",
      lastName: "Khorikov",
      bio: "",
      avatar: "https://via.placeholder.com/150",
      isFavorite: true,
    },
    {
      id: 2,
      firstName: "Kevin",
      lastName: "House",
      bio: "",
      avatar: "https://via.placeholder.com/150",
      isFavorite: false,
    },
    {
      id: 3,
      firstName: "Cory",
      lastName: "House",
      bio: "",
      avatar: "https://via.placeholder.com/150",
      isFavorite: true,
    },
  ];

  return props.children(speakers);
}
