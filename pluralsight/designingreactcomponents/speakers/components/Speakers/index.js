import React, { useState } from "react";
import Speaker from "../Speaker";
import SpeakersSearchBar from "../SpeakersSearchBar";

export default function Speakers() {
  const data = [
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

  const [searchQuery, setSearchQuery] = useState("");

  const [speakers, setSpeakers] = useState(data);

  function onFavoriteToggleHandler(speaker) {
    const index = speakers.indexOf(speaker);

    const newSpeakers = [...speakers];

    newSpeakers[index] = toggleSpeakerFavorite(speaker);

    setSpeakers(newSpeakers);
  }

  function toggleSpeakerFavorite(speaker) {
    return {
      ...speaker,
      isFavorite: !speaker.isFavorite,
    };
  }

  return (
    <>
      <SpeakersSearchBar
        searchQuery={searchQuery}
        setSearchQuery={setSearchQuery}
      />

      <div className="grid md:grid-cols-2 lg:grid-cols-3 grid-cols-1 gap-12">
        {speakers
          .filter((it) => {
            if (!searchQuery.length) {
              return true;
            }

            const target = `${it.firstName} ${it.lastName}`.toLocaleLowerCase();

            return target.includes(searchQuery.toLocaleLowerCase());
          })
          .map((it) => (
            <Speaker
              key={String(it.id)}
              firstName={it.firstName}
              lastName={it.lastName}
              bio={it.bio}
              avatar={it.avatar}
              isFavorite={it.isFavorite}
              onFavoriteToggle={() => onFavoriteToggleHandler(it)}
            />
          ))}
      </div>
    </>
  );
}
