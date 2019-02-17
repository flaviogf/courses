const express = require('express');

module.exports = (server) => {
  const router = express.Router();
  server.use('/api', router);

  const BillingCycleService = require('../api/billingCycle/billingCycleService');
  BillingCycleService.register(router, '/billingCycle');
}
