import React, { useState } from "react";
import ReactDOM from "react-dom";

ReactDOM.render(<Sample4 />, document.getElementById("root"));

function Sample1() {
  return <h1>Hello World!</h1>;
}

function Sample2() {
  return React.createElement("h1", null, "Hello World!!!");
}

function Sample3() {
  const [counter, setCounter] = useState(0);

  return <button onClick={() => setCounter(counter + 1)}>{counter}</button>;
}

function Sample4() {
  const [counter, setCounter] = useState(5);

  return <button onClick={() => setCounter(counter * 2)}>{counter}</button>;
}
