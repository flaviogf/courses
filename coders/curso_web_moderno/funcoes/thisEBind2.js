function Pessoa() {
  this.idade = 10

  const self = this;
  setTimeout(function () {
    self.idade++
    console.log(self.idade)
  }/*.bind(this)*/, 100)
}

new Pessoa()
