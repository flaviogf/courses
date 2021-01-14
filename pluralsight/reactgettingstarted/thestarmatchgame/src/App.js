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

  const onClickNumber = (number, currentStatus) => {
    if (currentStatus === "used") {
      return;
    }

    const newCandidateNumbers =
      currentStatus === "available"
        ? candidateNumbers.concat(number)
        : candidateNumbers.filter((cn) => cn !== number);

    if (utils.sum(newCandidateNumbers) !== stars) {
      setCandidateNumbers(newCandidateNumbers);

      return;
    }

    const newAvailableNumbers = availableNumbers.filter(
      (n) => !newCandidateNumbers.includes(n)
    );

    setStars(utils.randomSumIn(newAvailableNumbers, 9));

    setAvailableNumbers(newAvailableNumbers);

    setCandidateNumbers([]);
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
              onClick={onClickNumber}
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

function PlayNumber({ number, status, onClick }) {
  return (
    <button
      className="App__number"
      style={{ backgroundColor: colors[status] }}
      onClick={() => onClick(number, status)}
    >
      {number}
    </button>
  );
}

const utils = {
  sum: (arr) => arr.reduce((acc, curr) => acc + curr, 0),
  range: (min, max) => Array.from({ length: max - min + 1 }, (_, i) => min + i),
  random: (min, max) => min + Math.floor(Math.random() * (max - min + 1)),
  randomSumIn: (arr, max) => {
    const sets = [[]];
    const sums = [];
    for (let i = 0; i < arr.length; i++) {
      for (let j = 0, len = sets.length; j < len; j++) {
        const candidateSet = sets[j].concat(arr[i]);
        const candidateSum = utils.sum(candidateSet);
        if (candidateSum <= max) {
          sets.push(candidateSet);
          sums.push(candidateSum);
        }
      }
    }
    return sums[utils.random(0, sums.length - 1)];
  },
};

const colors = {
  available: "lightgray",
  used: "lightgreen",
  wrong: "lightcoral",
  candidate: "deepskyblue",
};
