import React from "react";

export default function SpeakersSearchBar() {
  return (
    <div className="mb-6">
      <input
        className="shadow appearence-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        type="text"
        id="username"
        placeholder="Search by name"
      />
    </div>
  );
}
