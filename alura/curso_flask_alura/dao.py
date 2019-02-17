from models import Jogo, Usuario

SQL_INSERI_JOGO = """
    INSERT INTO jogo (nome, categoria, console)
    VALUES (?, ?, ?)
"""

SQL_LISTA_JOGOS = """
    SELECT * FROM jogo
"""

SQL_BUSCA_POR_ID = """
    SELECT * FROM jogo
    WHERE id = ?
"""

SQL_DELETA = """
    DELETE FROM jogo
    WHERE id = ?
"""

SQL_ATUALIZA = """
    UPDATE jogo
    SET
        nome = ?,
        categoria = ?,
        console = ?
    WHERE id = ?
"""

SQL_BUSCA_USUARIO_POR_NOME_SENHA = """
    SELECT nome, senha FROM usuario
    WHERE nome = ? AND senha = ?
    LIMIT 1
"""


class JogoDao:
    def __init__(self, conexao):
        self.conexao = conexao

    def insere(self, jogo):
        self.conexao.execute(SQL_INSERI_JOGO, (jogo.nome, jogo.categoria, jogo.console))
        self.conexao.commit()

    def lista(self):
        jogos = []
        for row in self.conexao.execute(SQL_LISTA_JOGOS):
            jogo = Jogo(id_jogo=row[0], nome=row[1], categoria=row[2], console=row[3])
            jogos.append(jogo)
        return jogos

    def busca_por(self, id_jogo):
        cursor = self.conexao.cursor()
        cursor.execute(SQL_BUSCA_POR_ID, (id_jogo,))
        row = cursor.fetchone()
        return Jogo(id_jogo=row[0], nome=row[1], categoria=row[2], console=row[3])

    def deleta(self, id_jogo):
        self.conexao.execute(SQL_DELETA, (id_jogo,))
        self.conexao.commit()

    def atualizar(self, jogo):
        self.conexao.execute(SQL_ATUALIZA, (jogo.nome, jogo.categoria, jogo.console, jogo.id_jogo))
        self.conexao.commit()


class UsuarioDao:
    def __init__(self, conexao):
        self.conexao = conexao

    def buscar_por(self, nome, senha):
        cursor = self.conexao.cursor()
        cursor.execute(SQL_BUSCA_USUARIO_POR_NOME_SENHA, (nome, senha))
        row = cursor.fetchone()
        return Usuario(nome=row[0], senha=row[1])
