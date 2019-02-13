from unittest import TestCase

from carro import Carro


class TestCarro(TestCase):
    def test_carro_init(self):
        carro = Carro(velocidade_maxima=180)

        self.assertEqual(180, carro.velocidade_maxima)
        self.assertEqual(0, carro.velocidade_atual)

    def test_carro_acelera_ate_a_velocidade_maxima(self):
        carro = Carro(velocidade_maxima=180)

        for _ in range(10):
            carro.acelera(delta=100)

        self.assertEqual(180, carro.velocidade_atual)

    def test_carro_freia_ate_velocidade_zero(self):
        carro = Carro(velocidade_maxima=180)
        carro.acelera(delta=180)

        for _ in range(10):
            carro.freia(delta=100)

        self.assertEqual(0, carro.velocidade_atual)
