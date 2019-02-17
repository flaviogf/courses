from typing import Callable


class CaculadoraImposto:

    @staticmethod
    def calcula(valor_imposto: int, callback_calcula_imposto: Callable[[int], None]) -> None:
        valor_imposto *= 10
        print('Calculando valor imposto')
        print(f'Imposto calculado calculado')
        callback_calcula_imposto(valor_imposto)


if __name__ == '__main__':
    CaculadoraImposto.calcula(1000, (lambda valor_calculado: print(f'Valor {valor_calculado}')))
