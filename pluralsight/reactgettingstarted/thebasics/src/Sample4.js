import React, { useState } from "react";

export default function Sample4() {
  const [counter, setCounter] = useState(5);

  return <button onClick={() => setCounter(counter * 2)}>{counter}</button>;
}
