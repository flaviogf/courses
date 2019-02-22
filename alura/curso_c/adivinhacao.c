#include <stdio.h>

#define TENTATIVAS 5

int main() {
	printf("bem vindo ao jogo de advinhação\n");

	int numeroSecreto = 42;

	int numeroEscolhido;

	for (int i = 1; i <= TENTATIVAS; i++) {
		printf("tentativa %d de %d\n", i, TENTATIVAS);

		printf("escolha um numero:");
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
