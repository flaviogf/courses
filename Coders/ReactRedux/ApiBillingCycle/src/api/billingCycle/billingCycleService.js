const BillingCycle = require('./billingCycleSchema');
const errorHandler = require('../common/errorHandler');

BillingCycle.methods(['get', 'post', 'put', 'delete']);

BillingCycle.updateOptions({ new: true, runValidators: true });

BillingCycle.after('post', errorHandler).after('put', errorHandler);

BillingCycle.route('count', (req, res) => {
  BillingCycle.count({})
    .then((result) => {
      res.status(200).json({ valor: result });
    })
    .catch((erro) => {
      res.status(500).json({ erros: [erro] });
    });
});

BillingCycle.route('sumary', (req, res) => {
  BillingCycle.aggregate(
    { $project: { credito: { $sum: '$creditos.valor' }, debito: { $sum: '$debitos.valor' } } },
    { $group: { _id: null, credito: { $sum: '$credito' }, debito: { $sum: '$debito' } } },
    { $project: { _id: 0, credito: 1, debito: 1 } }
  )
    .then((result) => {
      res.status(200).json(result[0]);
    })
    .catch((erro) => {
      res.status(500).json({ erros: [erro] });
    });
});

module.exports = BillingCycle;
