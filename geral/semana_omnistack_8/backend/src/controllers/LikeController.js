const Dev = require("../models/Dev");

module.exports = {
  async store(req, res) {
    const userId = req.headers.user;
    const devId = req.params.id;

    const devLogged = await Dev.findById(userId);
    const devLiked = await Dev.findById(devId);

    devLogged.likes.push(devLiked);

    await devLogged.save();

    if (devLiked.likes.includes(userId)) {
      console.log("|> DEU MATCH!!!");
    }

    res.status(204).send();
  }
};
