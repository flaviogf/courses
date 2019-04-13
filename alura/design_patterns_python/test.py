import unittest

from calculador_desconto import CalculadorDesconto
from calculador_imposto import CalculadorImposto
from desconto import DescontoPorCincoItens, SemDesconto
from imposto import ICMS, ISS
from orcamento import Item, Orcamento


class ISSTests(unittest.TestCase):
    def test_calcula(self):
        item_a = Item(nome='Item A', valor=100)
        orcamento = Orcamento(itens=[item_a])
        imposto = ISS()

        imposto_calculado = imposto.calcula(orcamento)
        imposto_esperado = 10

        self.assertEqual(imposto_esperado, imposto_calculado)


class ICMSTests(unittest.TestCase):
    def test_calcula(self):
        item_a = Item(nome='Item A', valor=100)
        orcamento = Orcamento(itens=[item_a])
        imposto = ICMS()

        imposto_calculado = imposto.calcula(orcamento)
        imposto_esperado = 60

        self.assertEqual(imposto_esperado, imposto_calculado)


class CalculadorImpostoTests(unittest.TestCase):
    def test_calcula_icms(self):
        calculador = CalculadorImposto()
        item_a = Item(nome='Item A', valor=100)
        orcamento = Orcamento(itens=[item_a])
        imposto = ICMS()

        imposto_calculado = calculador.calcula(orcamento, imposto)
        imposto_esperado = 60

        self.assertEqual(imposto_esperado, imposto_calculado)

    def test_calcula_iss(self):
        calculador = CalculadorImposto()
        item_a = Item(nome='Item A', valor=100)
        orcamento = Orcamento(itens=[item_a])
        imposto = ISS()

        imposto_calculado = calculador.calcula(orcamento, imposto)
        imposto_esperado = 10

        self.assertEqual(imposto_esperado, imposto_calculado)


class DescontoPorCincoItensTests(unittest.TestCase):
    def test_calcula(self):
        itens = [Item(nome=f'Item {it}', valor=it) for it in range(1, 10)]

        orcamento = Orcamento(itens=itens)

        sut = DescontoPorCincoItens()

        desconto_calculado = sut.calcula(orcamento)
        desconto_esperado = 4.5

        self.assertEqual(desconto_calculado, desconto_esperado)


class SemDescontoTests(unittest.TestCase):
    def test_calcula(self):
        itens = [Item(nome=f'Item {it}', valor=it) for it in range(1, 10)]

        orcamento = Orcamento(itens=itens)

        sut = SemDesconto()

        desconto_calculado = sut.calcula(orcamento)
        desconto_esperado = 0

        self.assertEqual(desconto_calculado, desconto_esperado)


class CalculadorDescontoTests(unittest.TestCase):
    def test_calcula_desconto_por_cinco_itens(self):
        itens = [Item(nome=f'Item {it}', valor=it) for it in range(1, 10)]

        orcamento = Orcamento(itens=itens)

        sut = CalculadorDesconto()

        desconto_calculado = sut.calcula(orcamento)
        desconto_esperado = 4.5

        self.assertEqual(desconto_calculado, desconto_esperado)

    def test_calcula_sem_desconto(self):
        item_a = Item(nome='Item A', valor=10)
        orcamento = Orcamento(itens=[item_a])

        sut = CalculadorDesconto()

        desconto_calculado = sut.calcula(orcamento)
        desconto_esperado = 0

        self.assertEqual(desconto_calculado, desconto_esperado)
