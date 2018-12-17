from random import randrange


def jogo():
    palavras = []
    acertou = False
    enforcou = False
    erros = 0
    limite_erros = 6

    with(open("arquivo.txt", "r")) as arquivo:
        for l in arquivo:
            palavras.append(l.strip())

    palavra_secreta = palavras[randrange(0, len(palavras))].upper()

    letras_encontradas = ["_" for _ in palavra_secreta]

    while not acertou and not enforcou:
        print(letras_encontradas)

        letra_digitada = input("Digite uma letra: ").upper()

        index = 0

        if letra_digitada in palavra_secreta and letra_digitada not in letras_encontradas:

            for letra in palavra_secreta:

                if letra == letra_digitada:
                    letras_encontradas[index] = letra

                index += 1

        elif letra_digitada in letras_encontradas:

            print("letra ja encontrada")
        else:

            erros += 1

        if "_" not in letras_encontradas:

            acertou = True

            print(letras_encontradas)

        elif erros == limite_erros:

            enforcou = True

            print("Enforcou")


if __name__ == '__main__':
    jogo()
