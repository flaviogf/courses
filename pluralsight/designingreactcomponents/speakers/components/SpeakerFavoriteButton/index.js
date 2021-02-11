import React from "react";

export default function SpeakerFavoriteButton({
  isFavorite,
  onFavoriteToggle,
}) {
  return (
    <div
      className={isFavorite ? "heartredbutton" : "heartdarkbutton"}
      onClick={onFavoriteToggle}
    ></div>
  );
}
