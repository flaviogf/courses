"use strict";

const fs = require("fs");
const { promisify } = require("util");

module.exports.get = async (event) => {
  const template = await promisify(fs.readFile)("./index.html", "UTF-8");

  return {
    statusCode: 200,
    headers: {
      "Content-Type": "text/html",
    },
    body: template,
  };
};

module.exports.post = async (event) => {
  const data = event.body;

  return {
    statusCode: 200,
    body: data,
  };
};
