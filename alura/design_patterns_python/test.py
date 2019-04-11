import unittest

from calculador_imposto import CalculadorImposto
from imposto import ICMS, ISS
from orcamento import Orcamento


class ISSTests(unittest.TestCase):
    def test_calcula(self):
        orcamento = Orcamento()
        imposto = ISS()

        imposto_calculado = imposto.calcula(orcamento)
        imposto_esperado = 10

        self.assertEqual(imposto_esperado, imposto_calculado)


class ICMSTests(unittest.TestCase):
    def test_calcula(self):
        orcamento = Orcamento()
        imposto = ICMS()

        imposto_calculado = imposto.calcula(orcamento)
        imposto_esperado = 60

        self.assertEqual(imposto_esperado, imposto_calculado)


class CalculadorImpostoTests(unittest.TestCase):
    def test_calcula_icms(self):
        calculador = CalculadorImposto()
        orcamento = Orcamento()
        imposto = ICMS()

        imposto_calculado = calculador.calcula(orcamento, imposto)
        imposto_esperado = 60

        self.assertEqual(imposto_esperado, imposto_calculado)

    def test_calcula_iss(self):
        calculador = CalculadorImposto()
        orcamento = Orcamento()
        imposto = ISS()

        imposto_calculado = calculador.calcula(orcamento, imposto)
        imposto_esperado = 10

        self.assertEqual(imposto_esperado, imposto_calculado)
