from os import path, getcwd, mkdir

import re

ARQUIVO_ORIGINAL = path.join(getcwd(), 'receitas', 'originais', 'index.html')
ARQUIVO_ALTERADO = path.join(getcwd(), 'receitas', 'alterado')
FLAGS = re.IGNORECASE | re.MULTILINE | re.DOTALL


def aplica_cor(texto, regex, nome_grupo, cor):
    return re.sub(regex, rf'<span style="color: {cor};">\g<{nome_grupo}></span>', texto, flags=FLAGS)


with open(ARQUIVO_ORIGINAL, 'r') as file:
    conteudo = file.read()

regex_codigo = re.compile(r'<code>.*</code>', flags=FLAGS)

codigo = regex_codigo.search(conteudo).group()

codigo = aplica_cor(codigo, r'(?P<palavras_chaves>package|public|class|static)', 'palavras_chaves', 'yellow')

codigo = aplica_cor(codigo, r'(?P<tipos>System|String|void)', 'tipos', 'blue')

codigo = aplica_cor(codigo, r'(?P<tipo_string>"[\w\s]*")', 'tipo_string', 'orange')

if not path.isdir(ARQUIVO_ALTERADO):
  mkdir(ARQUIVO_ALTERADO)

conteudo = re.sub(regex_codigo, codigo, conteudo)

with open(path.join(ARQUIVO_ALTERADO, 'index.html'), 'w') as file:
  file.write(conteudo)
