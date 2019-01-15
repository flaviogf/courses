class Pessoa {
  String nome;
  double _idade;
  double _altura;

  Pessoa(this.nome, this._idade, this._altura);

  Pessoa.nasce(this.nome, this._altura) {
    this._idade = 0;
    print("${this.nome} nasceu");
    dorme();
  }

  double get idade => this._idade;

  double get altura => this._altura;

  void set altura(double value) {
    if (value >= 2.5) return;
    this._altura = value;
  }

  void dorme() {
    print("${this.nome} dormiu");
  }
}

void main() {
  print("OO");
  var flavio = Pessoa("Flavio", 21, 1.7);
  print(flavio.nome);
  print(flavio.idade);
  flavio.altura = 2.6;
  flavio.altura = 1.8;
  print(flavio.altura);
  var fernando = Pessoa.nasce("Fernando", 0.4);
  print(fernando.nome);
  print(fernando.idade);
}
