import sqlite3

from models import Usuario

conn = sqlite3.connect("jogoteca.db")

SQL_CRIA_TABELA_JOGO = """
    CREATE TABLE IF NOT EXISTS jogo (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        nome TEXT,
        categoria TEXT,
        console TEXT
    )
"""

SQL_CRIA_TABELA_USUARIO = """
    CREATE TABLE IF NOT EXISTS usuario (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        nome TEXT,
        senha TEXT
    )
"""

SQL_CRIA_USUARIOS = """
    INSERT INTO usuario (nome, senha)
    VALUES (?, ?)
"""


def cria_tabela_jogo():
    conn.execute(SQL_CRIA_TABELA_JOGO)


def cria_tabela_usuario():
    conn.execute(SQL_CRIA_TABELA_USUARIO)


def cria_usuarios():
    usuario1 = Usuario(nome="Flavio", senha="teste123")
    usuario2 = Usuario(nome="Fernando", senha="teste123")
    conn.executemany(SQL_CRIA_USUARIOS, [
        (usuario1.nome, usuario1.senha),
        (usuario2.nome, usuario2.senha)
    ])
    conn.commit()


def cria_banco():
    cria_tabela_jogo()
    cria_tabela_usuario()
    cria_usuarios()
    conn.close()


if __name__ == '__main__':
    cria_banco()
