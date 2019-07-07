const express = require("express");
const bodyParser = require("body-parser");

const app = express();

app.use(bodyParser.urlencoded({ extended: true }));

app.post("/insert", (req, res) => {
  console.log(req.body);
  res.send("Produto inserido");
});

app.post("/update/:id", (req, res) => {
  console.log(req.params.id);
  console.log(req.body);
  res.send("Produto atualizado");
});

app.listen(3000, console.log("listening 3000"));
