Array.prototype.$flatMap = function(cb) {
  return this.map(cb).reduce((arr, itens) => [...arr, ...itens], [])
}
