const pessoa = {
  nome: 'flavio',
  fala() {
    console.log(this.nome)
  }
}

pessoa.fala()

const fala = pessoa.fala

fala()

const falaPessoa = pessoa.fala.bind(pessoa)

falaPessoa()
