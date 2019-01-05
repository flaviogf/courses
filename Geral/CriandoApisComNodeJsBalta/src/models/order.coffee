mongoose = require 'mongoose'

schema = new mongoose.Schema
  customer:
    type: mongoose.Schema.Types.ObjectId
    ref: 'Customer'
    required: yes
  number:
    type: String
    required: yes
  createDate:
    type: Date
    required: yes
    default: Date.now
  status:
    type: String
    required: yes
    enum: ['created', 'done']
    default: 'created'
  items: [
    quantity:
      type: Number
      required: yes
      default: 1
    price:
      type: Number
      required: yes
    product:
      type: mongoose.Schema.Types.ObjectId
      ref: 'Product'
      required: yes
  ]

module.exports = mongoose.model 'Order', schema
