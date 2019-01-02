from typing import Callable

import pyperclip


def main():
    # testa_metodos_string()
    desafio()


def desafio():
    informacoes_tabela = [["teste", "teste", "teste"], ["item-1", "item-2-teste", "item-3"]]
    itens_tabela = []
    for valores in informacoes_tabela:
        itens_tabela += list(map(lambda x: len(x), valores))
    tamanho_maximo_coluna = max(itens_tabela) + 1
    for valor in informacoes_tabela:
        formata_itens: Callable[[str], str] = lambda x: x.center(tamanho_maximo_coluna)
        lista_formatada_ao_centro = list(map(formata_itens, valor))
        print(''.join(lista_formatada_ao_centro))


def testa_metodos_string():
    print("")
    print("\t tabulacao")
    print("\n quebra linha")
    print(r"\t \n \ string pura")
    print("""
        String multiplas linhas
    """)
    print('teste'[1:3] in 'fernandes')
    """
    Comentario
    """
    print("""teste
teste
teste""".split("\n"))
    print("teste".rjust(10, "*"))
    print("teste".ljust(10, "*"))
    print("  teste   ".strip())
    print("  teste   ".rstrip())
    print("  teste   ".lstrip())
    print("abcabctesteabc".strip("bac"))
    pyperclip.paste()
    input("pressione uma tecla")


if __name__ == '__main__':
    main()
