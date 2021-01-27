import React from "react";

export default function Speakers() {
  return (
    <SpeakersRenderProps>
      {(speakers) => (
        <>
          <div className="mb-6">
            <input
              className="shadow appearence-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              type="text"
              id="username"
              placeholder="Search by name"
            />
          </div>

          <div className="grid md:grid-cols-2 lg:grid-cols-3 grid-cols-1 gap-12">
            {speakers.map(
              ({ id, firstName, lastName, bio, avatar, isFavorite }) => (
                <div className="rounded overflow-hidden shadow-lg p-6" key={id}>
                  <div className="grid grid-cols-4 mb-6">
                    <div className="font-bold text-lg col-span-3">{`${firstName} ${lastName}`}</div>
                    <div className="flex justify-end">
                      <div
                        className={
                          isFavorite ? "heartredbutton" : "heartdarkbutton"
                        }
                      ></div>
                    </div>
                  </div>
                  <div className="mb-6">
                    <img src={avatar} alt={`${firstName} ${lastName}`} />
                  </div>
                  <div className="text-gray-600">
                    {bio.substr(0, 70) + "..."}
                  </div>
                </div>
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
