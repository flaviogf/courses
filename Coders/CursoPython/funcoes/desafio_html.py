#!/usr/local/bin/python3
def tag(tag, *args, **kwargs):
    conteudo = ''.join(args)
    attrs = ''.join(f'{k}="{v}" ' for k, v in kwargs.items())
    return f'<{tag} {attrs}>{conteudo}</{tag}>'


if __name__ == '__main__':
    print(
        tag('p',
            tag('span', 'Curso de python 3, por'),
            tag('strong', 'Juracy Filho', id='jf'),
            tag('span', 'e'),
            tag('strong', 'Leonardo Leitao', id='ll'),
            tag('span', '.'),
            html_class="alert"))
