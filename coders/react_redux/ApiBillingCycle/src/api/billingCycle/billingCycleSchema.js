const restful = require('node-restful');
const mongoose = restful.mongoose;

const CreditoSchema = new mongoose.Schema({
  nome: {
    type: String,
    required: true
  },
  valor: {
    type: Number,
    required: true,
    min: 0
  }
});

const DebitoSchema = new mongoose.Schema({
  nome: {
    type: String,
    required: true
  },
  valor: {
    type: Number,
    required: true,
    min: 0
  },
  status: {
    type: String,
    required: true,
    uppercase: true,
    enum: ['PAGO', 'AGENDADO']
  }
});

const BillingCycleSchema = new mongoose.Schema({
  nome: {
    type: String,
    required: true
  },
  mes: {
    type: Number,
    required: true,
    min: 1,
    max: 12
  },
  ano: {
    type: Number,
    required: true,
    min: 1970,
    max: 2100
  },
  creditos: [CreditoSchema],
  debitos: [DebitoSchema]
});

module.exports = restful.model('BillingCycle', BillingCycleSchema);
