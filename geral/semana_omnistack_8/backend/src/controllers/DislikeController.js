const Dev = require("../models/Dev");

module.exports = {
  async store(req, res) {
    const userId = req.headers.user;
    const devId = req.params.id;

    const devLogged = await Dev.findById(userId);
    const devDisliked = await Dev.findById(devId);

    devLogged.dislikes.push(devDisliked);

    await devLogged.save();

    res.status(204).send();
  }
};
