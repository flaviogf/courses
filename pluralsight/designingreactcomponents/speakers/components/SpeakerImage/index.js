import React from "react";
import { SimpleImg } from "react-simple-img";

export default function SpeakerImage({ avatar, firstName, lastName }) {
  return (
    <SimpleImg
      src={avatar}
      alt={`${firstName} ${lastName}`}
      animationDuration={1}
      height={150}
      width={150}
    />
  );
}
