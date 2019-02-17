from sys import argv, exit
from pyperclip import copy


def main():
    contas = {
        "treinaweb": "smnti@2017"
    }
    if len(argv) < 2:
        print("conta nao informada")
        exit()
    if argv[1] in contas:
        copy(contas[argv[1]])
        print("senha copiada")
    else:
        print("conta nao encontrada")
        exit()


if __name__ == '__main__':
    main()
