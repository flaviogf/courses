from functools import reduce
from os import path

import os
import shelve
import pprint
import re


def main():
    # testa_busca_diretorio_atual()
    # muda_diretorio_de_trabalho()
    # cria_diretorio()
    # busca_caminho_absoluto()
    # verifica_se_e_caminho_absoluto()
    # lista_arquivos_diretorios_e_soma_tamanho_total()
    # verifica_se_arquivo_ou_diretorio_existe()
    # le_linhas_arquivo()
    # le_arquivo()
    # escreva_em_um_arquivo_existente_ou_cria()
    # testa_modulo_shelve()
    # escreve_em_um_arquivo()
    busca_palavras_em_arquivos_py()


def busca_palavras_em_arquivos_py():
    palavra_a_busca = input("digite uma palavra: ")
    for nome_arquivo in os.listdir(os.getcwd()):
        if re.compile("\w\.py").search(nome_arquivo) is not None:
            with open(os.path.join(os.getcwd(), nome_arquivo)) as arquivo:
                busca = re.compile(palavra_a_busca).findall(arquivo.read())
                if len(busca):
                    print(busca)


def escreve_em_um_arquivo():
    gatos = [{'nome': 'nina', 'idade': 6}]
    dado_formatado = pprint.pformat(gatos)
    with open("gatos.py", 'w') as arquivo:
        arquivo.write(f'gatos = {dado_formatado} \n')
    from gatos import gatos
    print(gatos)


def testa_modulo_shelve():
    with shelve.open("chaves") as arquivo:
        arquivo['teste'] = 'teste'
        arquivo['gatos'] = ['gato1', 'gato2']
    with shelve.open('chaves') as arquivo:
        for chave, valor in arquivo.items():
            print(chave, valor)


def muda_diretorio():
    diretorio = path.join("C:\\", "Users", "Flavio Garcia", "Downloads")
    nome_arquivo = "teste.txt"
    os.chdir(diretorio)
    return diretorio, nome_arquivo


def escreva_em_um_arquivo_existente_ou_cria():
    _, nome_arquivo = muda_diretorio()
    with open(nome_arquivo, "w") as arquivo:
        arquivo.write("TESTE 4\n")
        arquivo.write("TESTE 5\n")
        arquivo.write("TESTE 6\n")


def le_linhas_arquivo():
    diretorio, nome_arquivo = muda_diretorio()
    if path.exists(path.join(diretorio, nome_arquivo)):
        with open(nome_arquivo) as arquivo:
            for indice, linha in enumerate(arquivo.readlines()):
                print(f"{indice} - {linha}")


def le_arquivo():
    diretorio, nome_arquivo = muda_diretorio()
    if path.exists(path.join(diretorio, nome_arquivo)):
        with open(nome_arquivo) as arquivo:
            conteudo = arquivo.read()
            print(conteudo)


def verifica_se_arquivo_ou_diretorio_existe():
    print(path.exists("C:\\Windows\\System32"))
    print(path.exists("C:\\System32"))
    print(path.isdir("C:\\Windows\\System32"))
    print(path.isdir("C:\\Windows\\System32\\calc.exe"))


def lista_arquivos_diretorios_e_soma_tamanho_total():
    diretorio_windows = "C:\\Windows\\System32"
    arquivos_windows = os.listdir(diretorio_windows)
    for arquivo in arquivos_windows:
        print(f"{arquivo} {path.getsize(path.join(diretorio_windows, arquivo))}")
    tamanho_arquivos = map(lambda x: path.getsize(path.join(diretorio_windows, x)), arquivos_windows)
    tamanho_total = reduce(lambda total, valor: total + valor, tamanho_arquivos, 0)
    print(f"{tamanho_total / 100_000_000:.2f} GB")


def testa_nome_diretorios():
    print(path.relpath("E:\\Cme\\Cme"))
    print(path.relpath("E:\\Cme", "E:\\"))
    print(path.dirname("E:\\Cme\Cme"))
    print(path.basename("E:\\Cme\Cme"))
    caminho_calculadora = "C:\\Windows\Sytem32\\calc.exe"
    print(path.basename(caminho_calculadora))  # retorna arquivo
    print(path.dirname(caminho_calculadora))  # retorna diretorio
    print(path.split(caminho_calculadora))  # retorna diretorio e arquivo
    print(tuple(caminho_calculadora.split(path.sep)))


def verifica_se_e_caminho_absoluto():
    print(path.isabs("./"))
    print(path.isabs("c:\\"))


def busca_caminho_absoluto():
    print(path.abspath("../"))


def cria_diretorio():
    diretorio = "c:\\TestePython\\Teste1\\Teste2"
    if not path.exists(diretorio):
        os.makedirs(diretorio)


def muda_diretorio_de_trabalho():
    os.chdir(path.join("c:\\"))
    print(os.getcwd())


def testa_busca_diretorio_atual():
    print(os.getcwd())


if __name__ == '__main__':
    main()
