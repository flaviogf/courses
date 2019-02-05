#!/usr/local/bin/python3

bloco_attrs = ('bloco_id', 'bloco_style')
ul_attrs = ('ul_id', 'ul_style')


def filtra_attrs(attrs, permitidos):
    return ' '.join(f'{k.split("_")[-1]}="{v}"' for k, v in attrs.items()
                    if k in permitidos)


def tag_bloco(conteudo, *args, classe='success', inline=False, **novos_attrs):
    tag = 'span' if inline else 'div'
    conteudo = conteudo if not callable(conteudo) else conteudo(
        *args, **novos_attrs)
    attrs = filtra_attrs(novos_attrs, bloco_attrs)
    return f'<{tag} class={classe} {attrs}>{conteudo}</{tag}>'


def tag_lista(*itens, **novos_attrs):
    lista = ''.join(f'<li>{item}</li>' for item in itens)
    attrs = filtra_attrs(novos_attrs, ul_attrs)
    return f'<ul {attrs}>{lista}</ul>'


if __name__ == '__main__':
    print(tag_bloco('teste1', bloco_style='teste'))
    print(tag_bloco('teste2', inline=True))
    print(tag_bloco('teste3', classe='danger'))
    print(tag_lista('teste1', 'teste2'))
    print(
        tag_bloco(
            tag_lista,
            'teste1',
            'teste2',
            classe='danger',
            bloco_style='style_bloco',
            ul_style='style_ul'))
