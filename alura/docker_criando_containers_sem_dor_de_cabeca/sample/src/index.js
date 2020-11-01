const express = require("express");
const nunjucks = require("nunjucks");
const path = require("path");

const app = express();

nunjucks.configure(path.resolve(__dirname, "views"), {
  autoescape: true,
  express: app,
});

app.use("/static", express.static(path.resolve(__dirname, "static")));

app.get("*", (req, res) => {
  const author = process.env.AUTHOR || "flaviogf";

  return res.render("index.html", { author });
});

app.listen(3333, () => console.log("It's running 🚀️"));
