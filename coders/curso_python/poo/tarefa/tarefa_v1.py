from datetime import datetime


class Tarefa:
    def __init__(self, descricao):
        self.descricao = descricao
        self.concluida = False
        self.criacao = datetime.now()

    def __str__(self):
        return self.descricao + (' (Concluida)' if self.concluida else '')

    def conclui(self):
        self.concluida = True
