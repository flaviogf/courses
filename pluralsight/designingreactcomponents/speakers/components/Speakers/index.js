import React, { useEffect, useState } from "react";
import axios from "axios";
import Speaker from "../Speaker";
import SpeakersSearchBar from "../SpeakersSearchBar";

export default function Speakers() {
  const [searchQuery, setSearchQuery] = useState("");

  const [speakers, setSpeakers] = useState([]);

  useEffect(() => {
    async function fetchSpeakers() {
      const response = await axios.get("http://localhost:4000/speakers");

      setSpeakers(response.data);
    }

    fetchSpeakers();
  }, []);

  async function onFavoriteToggleHandler(speaker) {
    const index = speakers.indexOf(speaker);

    const newSpeakers = [...speakers];

    const newSpeaker = toggleSpeakerFavorite(speaker);

    await axios.put(`http://localhost:4000/speakers/${speaker.id}`, newSpeaker);

    newSpeakers[index] = newSpeaker;

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
