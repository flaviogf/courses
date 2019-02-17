import adivinhacao
import forca


def main():
    jogo = int(input("Escolha um jogo (1) Adivinhacao (2) Forca: "))
    if jogo == 1:
        adivinhacao.jogo_while()
    else:
        forca.jogo()


if __name__ == '__main__':
    main()
