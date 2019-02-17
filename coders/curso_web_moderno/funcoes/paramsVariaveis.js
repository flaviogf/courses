function soma() {
  return Array.prototype.reduce.call(arguments, (t, v) => t += v, 0)
}

console.log(soma(10, 20, 40))

function soma2(...params) {
  return params.reduce((t, v) => t += v, 0)
}

console.log(soma2(10, 20, 40))

const soma3 = (...params) => params.reduce((t, v) => t += v, 0)

console.log(soma3(10, 20, 40))
