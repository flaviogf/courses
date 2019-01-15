abstract class Animal {
  String nome;
  double tamanho;

  Animal(this.nome, this.tamanho);

  void som();

  @override
  String toString() {
    return "Animal(Nome=$nome, Tamanho=$tamanho)";
  }
}

class Cachorro extends Animal {
  int fofura;

  Cachorro(String nome, double tamanho, this.fofura) : super(nome, tamanho);

  void som() {
    print("au au");
  }

  @override
  String toString() {
    return "Cachorro=(Nome=$nome, Tamanho=$tamanho, Fofura=$fofura)";
  }
}

class Gato extends Animal {
  bool estaEstavel;

  Gato(String nome, double tamanho, bool this.estaEstavel) : super(nome, tamanho);

  void som() {
    print("miau");
  }
}

void main() {
  Animal cachorro = Cachorro("Rex", 10, 10);
  print(cachorro);
  cachorro.som();
  Animal gato = Gato("Cat", 10, true);
  print(gato);
  gato.som();
}
