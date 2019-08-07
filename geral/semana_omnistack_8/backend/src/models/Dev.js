const mongoose = require("mongoose");

const DevSchema = new mongoose.Schema({
  login: {
    type: String,
    required: true
  },
  name: {
    type: String,
    required: true
  },
  bio: {
    type: String,
    required: true
  },
  avatar: {
    type: String,
    required: true
  },
  likes: [
    {
      type: mongoose.Schema.Types.ObjectId,
      ref: "Dev"
    }
  ],
  dislikes: [
    {
      type: mongoose.Schema.Types.ObjectId,
      ref: "Dev"
    }
  ]
});

module.exports = mongoose.model("Dev", DevSchema);
