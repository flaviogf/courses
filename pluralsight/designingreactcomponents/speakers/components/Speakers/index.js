import React, { useEffect, useState } from "react";
import axios from "axios";
import Speaker from "../Speaker";
import SpeakersSearchBar from "../SpeakersSearchBar";

export default function Speakers() {
  const REQUEST_STATUS = {
    loading: "loading",
    success: "success",
    error: "error",
  };

  const [searchQuery, setSearchQuery] = useState("");

  const [speakers, setSpeakers] = useState([]);

  const [status, setStatus] = useState(REQUEST_STATUS.loading);

  const [error, setError] = useState({});

  useEffect(() => {
    async function fetchSpeakers() {
      try {
        const response = await axios.get("http://localhost:4000/speakers");

        setSpeakers(response.data);

        setStatus(REQUEST_STATUS.success);
      } catch (e) {
        setStatus(REQUEST_STATUS.error);

        setError(e);
      }
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

  const isLoading = status === REQUEST_STATUS.loading;
  const hasError = status === REQUEST_STATUS.error;
  const success = status === REQUEST_STATUS.success;

  return (
    <>
      <SpeakersSearchBar
        searchQuery={searchQuery}
        setSearchQuery={setSearchQuery}
      />

      {isLoading && <div>Loading...</div>}

      {hasError && (
        <div>
          Loading error... Is the json-server running?
          <br />
          <b>ERROR: {error.message}</b>
        </div>
      )}

      {success && (
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
      )}
    </>
  );
}
