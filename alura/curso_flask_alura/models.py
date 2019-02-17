class Jogo:
    def __init__(self, nome, categoria, console, id_jogo=None):
        self.id_jogo = id_jogo
        self.nome = nome
        self.categoria = categoria
        self.console = console


class Usuario:
    def __init__(self, nome, senha, id_usuario=None):
        self.id_usuario = id_usuario
        self.nome = nome
        self.senha = senha
