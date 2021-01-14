import React, { useState } from "react";
import "./App.css";

export default function App() {
  const [stars, setStars] = useState(9);
  const [availableNumbers, setAvailableNumbers] = useState(utils.range(1, 9));
  const [candidateNumbers, setCandidateNumbers] = useState([]);

  const candidatesAreWrong = utils.sum(candidateNumbers) > stars;

  const numberStatus = (number) => {
    if (!availableNumbers.includes(number)) {
      return "used";
    }

    if (candidateNumbers.includes(number)) {
      return candidatesAreWrong ? "wrong" : "candidate";
    }

    return "available";
  };

  return (
    <div className="App__container">
      <div className="App__help">
        Pick 1 or more numbers that sum to the number of stars
      </div>

      <div className="App__game">
        <div className="App__left">
          <StarDisplay stars={stars} />
        </div>
        <div className="App__right">
          {utils.range(1, 9).map((number) => (
            <PlayNumber
              key={number}
              number={number}
              status={numberStatus(number)}
            />
          ))}
        </div>
      </div>
    </div>
  );
}

function StarDisplay({ stars }) {
  return utils
    .range(1, stars)
    .map((starId) => <div key={starId} className="App__star"></div>);
}

function PlayNumber({ number, status }) {
  return (
    <button className="App__number" style={{ backgroundColor: colors[status] }}>
      {number}
    </button>
  );
}

const utils = {
  sum: (arr) => arr.reduce((acc, curr) => acc + curr, 0),
  range: (min, max) => Array.from({ length: max - min + 1 }, (_, i) => min + i),
  random: (min, max) => min + Math.floor(Math.random() * (max - min + 1)),
};

const colors = {
  available: "lightgray",
  used: "lightgreen",
  wrong: "lightcoral",
  candidate: "deepskyblue",
};
