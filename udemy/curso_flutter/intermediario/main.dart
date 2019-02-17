void main() {
  var nota = 10.0;
  if (nota >= 6) {
    print("Aprovado");
  } else if (nota >= 4) {
    print("Recuperação");
  } else {
    print("Reprovado");
  }
  var nomePadrao = null ?? "Não informado";
  print(nomePadrao);
  print("FOR");
  for (var i = 0; i <= 10; i++) {
	  print(i);
  }
  print("WHILE");
  var i = 0;
  while(i <= 10) {
    print(i);
    i++;
  }
  print("DOWHILE");
  var j = 0;
  do {
    print(j);
    j++;
  } while(j <= 10);
  soma(10, 10);

  print(multiplicacao(20, 10));

  criaBotao("Confirmar", (n, x) {
    print("Botão criado ${n} ${x}");
  }, cor: "Azul");
}

void soma(double x, double y) {
  var res = x + y;
  print(res);
}

double multiplicacao(double x, double y) => x * y;

criaBotao(String titulo, Function callback, {String cor, double tamanho}) {
  print(titulo);
  print(cor ?? "Preto");
  print(tamanho ?? 10.5);
  callback(10, 10);
}
