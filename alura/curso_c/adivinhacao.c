#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main() {
	printf("bem vindo ao jogo de advinhação\n");

	srand(time(NULL));

	int numeroSecreto = rand() % 50;

	int numeroEscolhido;

	int dificuldade;

	int tentativas;

	printf("escolha um dificuldade (0) facil, (1) medio, (2) dificil: ");
	scanf("%d", &dificuldade);

	switch(dificuldade) {
		case 0:
			tentativas = 20;
			break;
		case 1:
			tentativas = 15;
			break;
		default:
			tentativas = 5;
			break;
	}

	for (int i = 1; i <= tentativas; i++) {
		printf("tentativa %d de %d\n", i, tentativas);

		printf("escolha um numero: ");
		scanf("%d", &numeroEscolhido);

		if (numeroEscolhido < 0) {
			printf("numero negativos nao sao permitidos\n");
			i--;
			continue;
		} else if (numeroEscolhido == numeroSecreto) {
			printf("voce acertou\n");
			break;
		} else if (numeroEscolhido > numeroSecreto) {
			printf("numero escolhido e maior que o numero secreto\n");
		} else {
			printf("numero escolhido e menor que o numero secreto\n");
		}
	}
}
