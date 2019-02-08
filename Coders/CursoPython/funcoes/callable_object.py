#!/usr/local/bin/python3


class Potencia:
    def __init__(self, expoente):
        self.expoente = expoente

    def __call__(self, base):
        return base**self.expoente


if __name__ == '__main__':
    quadrado = Potencia(2)
    cubo = Potencia(3)

    if callable(quadrado) and callable(cubo):
        print(f'Quadrado de 5 {quadrado(5)}')
        print(f'Cubo de 5 {cubo(5)}')
        print(Potencia(2)(9))
