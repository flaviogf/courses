from functools import reduce
from pprint import pprint
from typing import Dict, List


def main():
    # lista_aniversario()
    # contagem_de_letras()
    # contagem_itens_piquinique()
    inventario_de_jogo()


def lista_aniversario():
    pessoas = {"Flavio": "13-06-1997", "Fernando": "30-09-1994"}
    while True:
        nome_digitado = input("nome da pessoa: ")
        if not nome_digitado.isalpha():
            break
        if nome_digitado in pessoas:
            print(f"Aniversario {nome_digitado} : {pessoas[nome_digitado]}")
        else:
            data_aniversario = input("data de dnivarsario: ")
            pessoas[nome_digitado] = data_aniversario
            print("atualizado...")


def contagem_de_letras():
    dicionario_qtd_palavras = {}
    palavra = 'testando a quantidade de cada letra nesta frase'
    for l in palavra:
        if l.isspace():
            continue
        dicionario_qtd_palavras.setdefault(l, 0)
        dicionario_qtd_palavras[l] += 1

    pprint(dicionario_qtd_palavras)


def contagem_itens_piquinique():
    def total_produtos(convidados: Dict[str, Dict[str, int]], chave: str):
        total = 0
        for k, v in convidados.items():
            total += v.get(chave, 0)
        return total

    pessoas = {
        "Flavio": {"Maça": 2, "Pera": 10},
        "Fernando": {"Pera": 10}
    }
    print(total_produtos(pessoas, 'Pera'))
    print(total_produtos(pessoas, 'Maça'))


def inventario_de_jogo():
    inventario = {
        "tocha": 100,
        "gold": 250,
        "garrafa de agua": 50
    }

    adiciona_itens_no_inventario(inventario, ['banana', 'pera', 'pera'])

    for nome, quantidade in inventario.items():
        print(f"{quantidade} {nome}")

    total_items = reduce(lambda t, v: t + v, inventario.values())
    print(f"total de itens: {total_items}")


def adiciona_itens_no_inventario(inventario: Dict[str, int], itens: List[str]):
    for item in itens:
        inventario.setdefault(item, 0)
        inventario[item] += 1


if __name__ == "__main__":
    main()
