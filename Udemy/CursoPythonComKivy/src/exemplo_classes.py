class MeClasses:

    @classmethod
    def funcao(cls):
        print(f"chamando funcao da {cls.__name__}")


class Propriedades:

    def __init__(self):
        self._x = 0

    @property
    def x(self):
        print("chamando get x")
        return self._x

    @x.setter
    def x(self, valor):
        print("chamando set x")
        self._x = valor


class MeEstaticos:

    @staticmethod
    def funcao1():
        print("funcao1()")

    @staticmethod
    def funcao2(x, y, z):
        info = """
Nome {nome}
Quantidade Arqumentos = {quantidade}
Nome arqumentos = {nomes}
        """
        info = info.format(
            nome=MeEstaticos.funcao2.__name__,
            quantidade=MeEstaticos.funcao2.__code__.co_argcount,
            nomes=MeEstaticos.funcao2.__code__.co_varnames
        )
        print(info)


if __name__ == '__main__':
    MeClasses.funcao()
    MeEstaticos.funcao1()
    me = MeEstaticos()
    me.funcao1()
    MeEstaticos.funcao2(10, 20, 30)
    prop = Propriedades()
    prop.x = 10
    print(prop.x)
