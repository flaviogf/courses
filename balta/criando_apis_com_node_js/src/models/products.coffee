mongoose = require 'mongoose'

schema = new mongoose.Schema
  title:
    type: String
    required: yes
    trim: yes
  slug:
    type: String
    required: yes
    trim: yes
    index: yes
    unique: yes
  description:
    type: String
    required: yes
  price:
    type: Number
    required: yes
  active:
    type: Boolean
    required: yes
    default: yes
  tags: [
    type: String
    required: yes
  ]

module.exports = mongoose.model 'Product', schema
