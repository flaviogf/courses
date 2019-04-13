from typing import List


class Item:
    def __init__(self, nome: 'str', valor: 'float'):
        self.nome = nome
        self.valor = valor


class Orcamento:
    def __init__(self, itens: 'List[Item]' = []):
        self.itens = itens

    @property
    def valor(self):
        return sum([it.valor for it in self.itens])
