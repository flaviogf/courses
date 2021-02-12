import React, { useEffect, useReducer, useState } from "react";
import axios from "axios";
import Speaker from "../Speaker";
import SpeakersSearchBar from "../SpeakersSearchBar";

export default function Speakers() {
  const REQUEST_STATUS = {
    loading: "loading",
    success: "success",
    error: "error",
  };

  function reducer(state, action) {
    switch (action.type) {
      case "GET_ALL_SUCCESS":
        return {
          ...state,
          speakers: action.payload,
          status: REQUEST_STATUS.success,
        };
      case "GET_ALL_FAILURE":
        return {
          ...state,
          error: action.payload,
          status: REQUEST_STATUS.error,
        };
      case "PUT_SUCCESS":
        const index = state.speakers
          .map((it) => it.id)
          .indexOf(action.payload.id);

        const newSpeakers = [...state.speakers];

        newSpeakers[index] = action.payload;

        return {
          ...state,
          speakers: newSpeakers,
        };
      case "PUT_FAILURE":
        return {
          ...state,
          error: action.payload,
        };
      default:
        return state;
    }
  }

  const [searchQuery, setSearchQuery] = useState("");

  const [{ speakers, status, error }, dispatch] = useReducer(reducer, {
    speakers: [],
    status: REQUEST_STATUS.loading,
    error: {},
  });

  useEffect(() => {
    async function fetchSpeakers() {
      try {
        const response = await axios.get("http://localhost:4000/speakers");

        dispatch({
          type: "GET_ALL_SUCCESS",
          payload: response.data,
        });
      } catch (e) {
        dispatch({
          type: "GET_ALL_FAILURE",
          payload: e,
        });
      }
    }

    fetchSpeakers();
  }, []);

  async function onFavoriteToggleHandler(speaker) {
    try {
      const newSpeaker = toggleSpeakerFavorite(speaker);

      await axios.put(
        `http://localhost:4000/speakers/${speaker.id}`,
        newSpeaker
      );

      dispatch({
        type: "PUT_SUCCESS",
        payload: newSpeaker,
      });
    } catch (e) {
      dispatch({
        type: "PUT_FAILURE",
        payload: e,
      });
    }
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
