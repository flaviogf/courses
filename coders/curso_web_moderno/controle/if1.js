function seForVerdadeEuFalo(valor) {
  if (valor) {
    console.log('É verdade ... ' + valor)
  }
}

seForVerdadeEuFalo()
seForVerdadeEuFalo(null)
seForVerdadeEuFalo(undefined)
seForVerdadeEuFalo(NaN)
seForVerdadeEuFalo(0)
seForVerdadeEuFalo('')
seForVerdadeEuFalo([1, 2])
seForVerdadeEuFalo(' ')
seForVerdadeEuFalo({})
seForVerdadeEuFalo([])
