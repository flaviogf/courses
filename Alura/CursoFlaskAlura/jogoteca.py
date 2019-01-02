import sqlite3
import time
import os

from flask import Flask, render_template, redirect, request, session, flash, url_for, abort, send_from_directory

from dao import JogoDao, UsuarioDao
from models import Jogo

from os import path

app = Flask(__name__)

UPLOAD_FOLDER = path.join(os.getcwd(), 'uploads')
app.config['UPLOAD_FOLDER'] = UPLOAD_FOLDER

app.secret_key = "calopsita"

chave_sessao_usuario = "usuario_logado"

conexao = sqlite3.connect("jogoteca.db")

jogo_dao = JogoDao(conexao)

usuario_dao = UsuarioDao(conexao)


@app.route("/")
def index():
    lista = jogo_dao.lista()
    return render_template("jogos.html", titulo="Jogos", jogos=lista)


@app.route("/login")
def login():
    return render_template("login.html", titulo="Login")


@app.route("/novo")
def novo():
    if chave_sessao_usuario not in session or session[chave_sessao_usuario] is None:
        return redirect(url_for("login"))
    return render_template("novo_jogo.html", titulo="Novo Jogo")


@app.route("/editar/<int:id_jogo>")
def editar(id_jogo):
    if chave_sessao_usuario not in session or session[chave_sessao_usuario] is None:
        return redirect(url_for("login"))
    try:
        jogo = jogo_dao.busca_por(id_jogo)
        capa_jogo = busca_imagem(jogo.nome)
        return render_template("editar.html", titulo="Editar jogo", jogo=jogo, capa_jogo=capa_jogo)
    except TypeError:
        return abort(404)


@app.route("/atualizar", methods=["POST", ])
def atualizar():
    jogo = Jogo(
        nome=request.form["nome"],
        categoria=request.form["categoria"],
        console=request.form["console"],
        id_jogo=request.form["id_jogo"]
    )
    jogo_dao.atualizar(jogo)
    imagem = request.files["imagem"]
    timestamp = time.time()
    arquivo = path.join(app.config["UPLOAD_FOLDER"], f"capa{jogo.nome}{timestamp}.jpg")
    remove_imagem(jogo.nome)
    imagem.save(arquivo)
    return redirect(url_for("index"))


@app.route("/deletar/<int:id_jogo>")
def deletar(id_jogo):
    if chave_sessao_usuario not in session or session[chave_sessao_usuario] is None:
        return redirect(url_for("login"))
    jogo_dao.deleta(id_jogo)
    return redirect(url_for("index"))


@app.route("/criar", methods=["POST", ])
def criar():
    jogo = Jogo(request.form["nome"], request.form["categoria"], request.form["console"])
    imagem = request.files["imagem"]
    timestamp = time.time()
    arquivo = path.join(app.config["UPLOAD_FOLDER"], f"capa{jogo.nome}{timestamp}.jpg")
    jogo_dao.insere(jogo)
    remove_imagem(jogo.nome)
    imagem.save(arquivo)
    return redirect(url_for('index'))


@app.route("/autenticar", methods=["POST", ])
def autenticar():
    nome = request.form["usuario"]
    senha = request.form["senha"]
    try:
        usuario = usuario_dao.buscar_por(nome, senha)
        session[chave_sessao_usuario] = usuario.nome
        flash("{}, logou".format(usuario.nome))
        return redirect(url_for("index"))
    except TypeError:
        flash("Usuário ou senha inválidos")
        return redirect(url_for("login"))


@app.route("/deslogar")
def deslogar():
    session[chave_sessao_usuario] = None
    flash("Usuario deslogado")
    return redirect(url_for("index"))


@app.route("/imagens/<nome_arquivo>")
def imagens(nome_arquivo):
    return send_from_directory(app.config['UPLOAD_FOLDER'], nome_arquivo)


def remove_imagem(nome):
    arquivos = filter(lambda x: x.startswith(f'capa{nome}'), os.listdir(app.config['UPLOAD_FOLDER']))
    for arquivo in arquivos:
        os.remove(path.join(app.config['UPLOAD_FOLDER'], arquivo))


def busca_imagem(nome):
    for arquivo in os.listdir(app.config['UPLOAD_FOLDER']):
        if arquivo.startswith(f"capa{nome}"):
            return arquivo


if __name__ == '__main__':
    app.run()
