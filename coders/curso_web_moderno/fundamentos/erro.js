function imprime(nome = '') {
  try {
    console.log(nome.toUpperCase())
  } catch (error) {
    throw { message: 'Nome não pode ser nulo' }
  }
}


try {
  imprime('Flavio')
  imprime(null)
} catch (error) {
  console.log(error)
  throw error.message
} finally {
  console.log('FIM')
}
