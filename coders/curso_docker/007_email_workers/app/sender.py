import json

import redis
from bottle import post, request, route, run

fila = redis.Redis(host='queue')


def envia_para_fila(email):
    email = json.dumps(email, indent=4, sort_keys=True)
    print('app', email)
    fila.rpush('emails', email)


@post('/')
def index():
    assunto = request.forms.get('assunto')
    mensagem = request.forms.get('mensagem')
    email = {'assunto': assunto, 'mensagem': mensagem}
    envia_para_fila(email)
    return f'Mensagem enfileirada {assunto} {mensagem}'


if __name__ == "__main__":
    run(host='0.0.0.0', port=8080)
