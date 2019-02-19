from datetime import datetime


class TarefaNaoEncontrada(Exception):
    ...


class Tarefa:
    def __init__(self, descricao, vencimento=None):
        self.descricao = descricao
        self.concluida = False
        self.criacao = datetime.now()
        self.vencimento = vencimento

    def __str__(self):
        if self.concluida:
            return self.descricao + ' (Concluida)'
        elif self.vencimento and datetime.now() > self.vencimento:
            return self.descricao + ' (Vencida)'
        else:
            return self.descricao

    def conclui(self):
        self.concluida = True


class Projeto:
    def __init__(self, nome):
        self.nome = nome
        self.tarefas = []

    def __iter__(self):
        return self.tarefas.__iter__()

    def __iadd__(self, tarefa):
        self.add(tarefa)
        return self

    def add(self, tarefa):
        if isinstance(tarefa, Tarefa):
            self.tarefas.append(tarefa)
        else:
            self.tarefas.append(Tarefa(tarefa))

    def procura(self, nome_tarefa):
        try:
            return [it for it in self.tarefas if it.descricao == nome_tarefa][0]
        except IndexError as e:
            raise TarefaNaoEncontrada(e)

    @property
    def pendentes(self):
        return [it for it in self.tarefas if not it.concluida]
