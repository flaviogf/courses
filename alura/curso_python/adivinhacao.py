import random


def jogo_while():
    numero_secreto = random.randrange(0, 101)

    print(numero_secreto)

    dificuldade = int(input("Escolha uma dificuldade: (1) Facil (2) Médio (3) Dificil: "))

    if dificuldade == 1:
        total_tentativas = 20
    elif dificuldade == 2:
        total_tentativas = 10
    else:
        total_tentativas = 3

    tentativa_atual = 0

    pontuacao = 100

    while tentativa_atual < total_tentativas:

        tentativa_atual += 1

        print("Tentativa {} de {}".format(tentativa_atual, total_tentativas))

        numero_digitado = input("Digite um numero: ")

        numero_a_comparar = int(numero_digitado)

        if numero_a_comparar == numero_secreto:
            print("acertou")
            break
        elif numero_a_comparar > numero_secreto:
            print("numero digitado maior")
        elif numero_a_comparar < numero_secreto:
            print("numero digitado menor")

        pontuacao -= numero_a_comparar

    print("Fim de jogo com while {} ponto(s)".format(pontuacao))


def jogo_for():
    numero_secreto = random.randrange(0, 101)

    print(numero_secreto)

    dificuldade = int(input("Escolha uma dificuldade: (1) Facil (2) Médio (3) Dificil: "))

    if dificuldade == 1:
        total_tentativas = 20
    elif dificuldade == 2:
        total_tentativas = 10
    else:
        total_tentativas = 3

    pontuacao = 100

    for rodada in range(1, total_tentativas + 1):
        print("Tentativa {} de {}".format(rodada, total_tentativas))

        numero_digitado = input("Digite um numero: ")

        numero_a_comparar = int(numero_digitado)

        if numero_a_comparar == numero_secreto:
            print("acertou")
            break
        elif numero_a_comparar < numero_secreto:
            print("numero digitado menor")
        elif numero_a_comparar > numero_secreto:
            print("numero digitado maior")

        pontuacao -= numero_a_comparar

    print("Fim de jogo for")
