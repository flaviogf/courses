const axios = require("axios");
const Dev = require("../models/Dev");

module.exports = {
  async index(req, res) {
    const devLogged = await Dev.findById(req.headers.user);

    const devs = await Dev.find({
      $and: [
        {
          _id: { $ne: devLogged._id }
        },
        {
          _id: { $nin: devLogged.likes }
        },
        {
          _id: { $nin: devLogged.dislikes }
        }
      ]
    });

    return res.json(devs);
  },
  async store(req, res) {
    const { login } = req.body;

    const response = await axios.get(`https://api.github.com/users/${login}`);

    const { name, bio, avatar_url: avatar } = response.data;

    const dev = await Dev.create({
      login,
      name,
      bio,
      avatar
    });

    res.json(dev);
  }
};
