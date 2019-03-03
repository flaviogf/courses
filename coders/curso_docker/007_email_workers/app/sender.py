from bottle import run, request, route, post


@post('/')
def index():
    assunto = request.forms.get('assunto')
    mensagem = request.forms.get('mensagem')
    return f'Mensagem enfileirada {assunto} {mensagem}'


if __name__ == "__main__":
    run(host='0.0.0.0', port=8080)
