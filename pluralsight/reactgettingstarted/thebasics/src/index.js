import React from "react";
import ReactDOM from "react-dom";

ReactDOM.render(<Sample2 />, document.getElementById("root"));

function Sample1() {
  return <h1>Hello World!</h1>;
}

function Sample2() {
  return React.createElement("h1", null, "Hello World!!!");
}
