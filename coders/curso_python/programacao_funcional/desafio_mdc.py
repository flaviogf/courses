def mdc_v1(*numeros):
    divisores = range(1, sorted(numeros)[-1])

    maior_divisor = max([
        d for d in divisores if numeros[-2] % d == 0 and numeros[-1] % d == 0
    ])

    return maior_divisor


def mdc_v2(*numeros):
    def calc(divisor):
        return divisor if sum([n % divisor
                               for n in numeros]) == 0 else calc(divisor - 1)

    return calc(min(numeros))
