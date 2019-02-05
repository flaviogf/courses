#!/usr/local/bin/python3


def tag_bloco(texto, classe='success', inline=False):
    tag = 'span' if inline else 'div'
    return f'<{tag} class={classe}>{texto}</{tag}>'


def tag_lista(*itens):
    lista = ''.join(f'<li>{item}</li>' for item in itens)
    return f'<ul>{lista}</ul>'


if __name__ == '__main__':
    print(tag_bloco('teste1'))
    print(tag_bloco('teste2', inline=True))
    print(tag_bloco('teste3', classe="danger"))
    print(tag_lista('teste1', 'teste2'))
