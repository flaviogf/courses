const express = require("express");
const DevController = require("./controllers/DevController");
const LikeController = require("./controllers/LikeController");

const routes = express.Router();

routes.post("/devs", DevController.store);
routes.post("/devs/:id/like", LikeController.store);

module.exports = routes;
