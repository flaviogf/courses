const axios = require("axios");
const Dev = require("../models/Dev");

module.exports = {
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
