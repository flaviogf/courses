from unittest import TestCase

from tarefa_v1 import Tarefa


class TestTarefa(TestCase):
    def test_tarefa_init(self):
        tarefa = Tarefa('Lavar pratos')

        self.assertEqual('Lavar pratos', tarefa.descricao)
        self.assertFalse(tarefa.concluida)
        self.assertIsNotNone(tarefa.criacao)

    def test_tarefa_conclui(self):
        tarefa = Tarefa('Lavar pratos')

        tarefa.conclui()

        self.assertTrue(tarefa.concluida)

    def test_tarefa_str(self):
        tarefa = Tarefa('Lavar pratos')

        self.assertEqual('Lavar pratos', tarefa.__str__())

    def test_tarefa_str_concluida(self):
        tarefa = Tarefa('Lavar pratos')

        tarefa.conclui()

        self.assertEqual('Lavar pratos (Concluida)', tarefa.__str__())
