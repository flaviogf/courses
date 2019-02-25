from abc import ABC, abstractmethod


class Humano(ABC):
    def __init__(self, nome):
        self.nome = nome
        self._idade = 0

    @staticmethod
    @abstractmethod
    def inteligente():
        ...

    @classmethod
    def evoluido(cls):
        return cls.especie == cls.especies()[-1]

    @property
    def idade(self):
        return self._idade

    @idade.setter
    def idade(self, value):
        self._idade = value

    @staticmethod
    def especies():
        especies = ('Habilis', 'Erectus', 'Neanderthalensis', 'Sapiens')
        return ('Australopiteco', ) + tuple(('Homo' + it for it in especies))


class HomoSapien(Humano):
    especie = Humano.especies()[-1]

    @staticmethod
    def inteligente():
        return True


class Neanderthal(Humano):
    ...
