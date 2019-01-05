exports.get = (req, res, next) ->
  res
    .status 200
    .send title: 'Node Store Api', version: '0.0.1'
