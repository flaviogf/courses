from functools import reduce
from typing import List


def main():
    gatos = []
    while True:
        nome_gato = input("nome: ")
        if nome_gato.isalpha():
            gatos.append(nome_gato)
        else:
            break

    gato_procurado = input("digite o nome do gato procurado:")
    if gato_procurado in gatos:
        print(f'gato encontrado: {gato_procurado}')
    else:
        print("gato não encontrado")


def passando_referencia(lista: List[str]):
    lista.append('teste')
    lista.append('teste2')
    lista.append('teste3')


def formata_lista(lista: List[str]) -> str:
    ultimo_elemento = lista[-1]
    return reduce(lambda t, v: t + f' and {v}' if v == ultimo_elemento else t + f', {v}', lista)


if __name__ == '__main__':
    # main()
    nomes = []
    passando_referencia(nomes)
    print(nomes)
    nomes_formatados = formata_lista(nomes)
    print(nomes_formatados)
