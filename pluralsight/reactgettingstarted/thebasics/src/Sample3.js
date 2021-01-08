import React, { useState } from "react";

export default function Sample3() {
  const [counter, setCounter] = useState(0);

  return <button onClick={() => setCounter(counter + 1)}>{counter}</button>;
}
