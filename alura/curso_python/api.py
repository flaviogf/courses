from flask import Flask, jsonify

from oo.cliente import Cliente
from oo.conta import Conta

app = Flask(__name__)


@app.route("/")
def hello():
    conta = Conta(123, "Flavio", 1000, 1000)
    conta.saca(500)
    conta.extrato()
    return "Codigo banco {1} - Saldo {0}".format(conta.saldo, Conta.codigo_banco())


@app.route("/cliente")
def cliente():
    cliente_teste = Cliente("Flavio")
    cliente_teste.nome = "Fernando"
    return jsonify(nome=cliente_teste.nome)


if __name__ == '__main__':
    app.run()
