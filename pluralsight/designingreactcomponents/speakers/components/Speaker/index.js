import React from "react";
import SpeakerFavoriteButton from "../SpeakerFavoriteButton";
import SpeakerImage from "../SpeakerImage";

export default function Speaker({
  firstName,
  lastName,
  bio,
  avatar,
  isFavorite,
}) {
  return (
    <div className="rounded overflow-hidden shadow-lg p-6">
      <div className="grid grid-cols-4 mb-6">
        <div className="font-bold text-lg col-span-3">{`${firstName} ${lastName}`}</div>
        <div className="flex justify-end">
          <SpeakerFavoriteButton isFavorite={isFavorite} />
        </div>
      </div>
      <div className="mb-6">
        <SpeakerImage
          avatar={avatar}
          firstName={firstName}
          lastName={lastName}
        />
      </div>
      <div className="text-gray-600">{bio.substr(0, 70) + "..."}</div>
    </div>
  );
}
