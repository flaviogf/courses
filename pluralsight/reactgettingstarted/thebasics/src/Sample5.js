import React, { useState } from "react";

export default function Sample5() {
  const [counter, setCounter] = useState(0);

  return (
    <>
      <Button onClick={() => setCounter(counter + 1)} />
      <Display message={counter} />
    </>
  );
}

function Button(props) {
  return <button onClick={props.onClick}>UP</button>;
}

function Display(props) {
  return <h1>{props.message}</h1>;
}
