from typing import Callable


def hello(nome: str) -> Callable[[], None]:
    return lambda: print(f'Hello {nome}')


def repete_funcao(funcao: Callable[[], None], qtd: int) -> None:
    for i in range(qtd):
        funcao()


def altera_variavel_global():
    global eggs
    eggs = 'Variavel Global Alterada em Função'


e_par: Callable[[float], bool] = lambda x: x % 2 == 0


def collatz(number: int):
    if e_par(number):
        retorno = number // 2
        print(retorno)
        return retorno
    else:
        retorno = number * 3 + 1
        print(retorno)
        return retorno


divisao: Callable[[float, float], float] = lambda n1, n2: n1 / n2


def testa_funcoes():
    repete_funcao(hello('Flavio'), 2)
    altera_variavel_global()
    print(eggs)
    try:
        print(divisao(2, 2))
        print(divisao(2, 3))
        print(divisao(2, 0))
    except ZeroDivisionError:
        print('Erro divisão por zero')


if __name__ == '__main__':
    # testa_funcoes()
    try:
        numero = int(input('digite um numero: '))
        valor = collatz(numero)
        while True:
            if valor == 1:
                break
            else:
                valor = collatz(valor)
    except ValueError:
        print('numero digitado invalido')
