Number.prototype.$entre = function (inicio, fim) {
  return this >= inicio && this <= fim
}

function imprimeResultado(nota = 0) {
  switch (nota) {
    case 10:
    case 9:
      console.log('Quadro de Honra')
      break
    case 8:
    case 7:
      console.log('Aprovado')
      break
    case 0:
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
    case 6:
      console.log('Recuperacao')
      break
    default:
      console.log('Nota Invalida')
  }
}

imprimeResultado(10)
imprimeResultado(6)
imprimeResultado(-1)
