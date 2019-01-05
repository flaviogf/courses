mongoose = require 'mongoose'

schema = new mongoose.Schema
  name:
    type: String
    required: yes
  email:
    type: String
    required: yes
    unique: yes
    index: yes
  password:
    type: String
    required: yes

module.exports = mongoose.model 'Customer', schema
