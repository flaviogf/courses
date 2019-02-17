const _ = require('lodash');

module.exports = (req, res, next) => {
  const bundle = res.locals.bundle;
  if (bundle.errors) {
    const erros = parseErrors(bundle.errors);
    res.status(500).json({ erros });
  } else {
    next();
  }
}

const parseErrors = (nodeRestfulErrors) => {
  let erros = [];
  _.forIn(nodeRestfulErrors, (error) => erros.push(error.message));
  return erros;
}
