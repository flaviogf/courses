const express = require("express");
const DevController = require("./controllers/DevController");
const LikeController = require("./controllers/LikeController");
const DislikeController = require("./controllers/DislikeController");

const routes = express.Router();

routes.get("/devs", DevController.index);
routes.post("/devs", DevController.store);
routes.post("/devs/:id/like", LikeController.store);
routes.post("/devs/:id/dislike", DislikeController.store);

module.exports = routes;
