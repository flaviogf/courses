from unittest import TestCase
from datetime import datetime, timedelta

from tarefa_v2 import Tarefa, Projeto, TarefaNaoEncontrada


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
        tarefa_1 = Tarefa('Lavar pratos')
        tarefa_2 = Tarefa('Ir ao supermercado',
                          vencimento=datetime.now() - timedelta(days=1))

        tarefa_3 = Tarefa('Estudar')
        tarefa_3.conclui()
        self.assertEqual('Lavar pratos', tarefa_1.__str__())
        self.assertEqual('Ir ao supermercado (Vencida)', tarefa_2.__str__())
        self.assertEqual('Estudar (Concluida)', tarefa_3.__str__())

    def test_tarefa_str_concluida(self):
        tarefa = Tarefa('Lavar pratos')

        tarefa.conclui()

        self.assertEqual('Lavar pratos (Concluida)', tarefa.__str__())


class TestProjeto(TestCase):
    def test_projeto_init(self):
        projeto = Projeto('Casa')

        self.assertEqual('Casa', projeto.nome)
        self.assertListEqual([], projeto.tarefas)

    def test_projeto_adiciona_tarefa(self):
        projeto = Projeto('Casa')

        tarefa = Tarefa('lavar prato')

        projeto.add(tarefa)

        self.assertListEqual([tarefa], projeto.tarefas)

    def test_projeto_adiciona_tarefa_passando_descricao(self):
        projeto = Projeto('Casa')

        projeto.add('lavar prato')

        tarefa = projeto.tarefas[-1]

        self.assertIsInstance(tarefa, Tarefa)

    def test_projeto_iter(self):
        projeto = Projeto('Casa')

        projeto.add('lavar prato')
        projeto.add('lavar roupa')

        for tarefa in projeto:
            self.assertIsInstance(tarefa, Tarefa)

    def test_projeto_iadd(self):
        projeto = Projeto('Casa')

        lavar_prato = Tarefa('lavar prato')

        projeto += lavar_prato

        self.assertListEqual([lavar_prato], projeto.tarefas)

    def test_projeto_pendentes(self):
        projeto = Projeto('Casa')

        projeto += 'lavar prato'
        projeto += 'ir ao supermercado'

        self.assertEqual(2, len(projeto.pendentes))

    def test_projeto_procura(self):
        projeto = Projeto('Casa')

        projeto += 'lavar prato'
        projeto += 'ir ao supermercado'

        tarefa = projeto.procura('lavar prato')

        self.assertEqual('lavar prato', tarefa.descricao)

    def test_projeto_procura_quando_nao_for_encontrado(self):
        projeto = Projeto('Casa')

        projeto += 'lavar prato'
        projeto += 'ir ao supermercado'

        with self.assertRaises(TarefaNaoEncontrada):
            projeto.procura('lavar pratos')
