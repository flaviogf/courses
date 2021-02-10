import React from "react";

export default function SpeakerFavoriteButton({ isFavorite }) {
  return (
    <div className={isFavorite ? "heartredbutton" : "heartdarkbutton"}></div>
  );
}
