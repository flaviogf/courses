#!/usr/local/bin/python3


def tag_bloco(conteudo, *args, classe='success', inline=False):
    tag = 'span' if inline else 'div'
    conteudo = conteudo if not callable(conteudo) else conteudo(*args)
    return f'<{tag} class={classe}>{conteudo}</{tag}>'


def tag_lista(*itens):
    lista = ''.join(f'<li>{item}</li>' for item in itens)
    return f'<ul>{lista}</ul>'


if __name__ == '__main__':
    print(tag_bloco('teste1'))
    print(tag_bloco('teste2', inline=True))
    print(tag_bloco('teste3', classe='danger'))
    print(tag_lista('teste1', 'teste2'))
    print(tag_bloco(tag_lista, 'teste1', 'teste2', classe='danger'))
