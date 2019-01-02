import os
import shutil
from _datetime import datetime
from zipfile import ZipFile

from send2trash import send2trash


def cria_arquivo_zip():
    inicio = datetime.now()
    with ZipFile("teste.zip", "w")as zip_file:
        for arquivo in filter(lambda x: x != "venv" and x != "teste.zip", os.listdir()):
            zip_file.write(arquivo)
    fim = datetime.now()
    print((fim - inicio).microseconds)


def extrai_um_arquivo():
    with ZipFile("arquivo.zip") as zip_file:
        print(zip_file.namelist())
        if "arquivo/teste.txt" in zip_file.namelist():
            zip_file.extract("arquivo/teste.txt")


def extrai_todos_arquivos():
    with ZipFile("arquivo.zip") as zip_file:
        zip_file.extractall(u"c:\\")


def lista_arquivo_zip():
    with ZipFile("arquivo.zip") as zip_file:
        for arquivo in zip_file.filelist:
            print(arquivo.filename)


def copia_move_deleta():
    os.chdir("c:\\")
    arquivos_python = "arquivos_python"
    arquivos_pytnon_bkp = "arquivos_python_bkp"
    if arquivos_pytnon_bkp in os.listdir(os.getcwd()):
        shutil.rmtree(f"c:\\{arquivos_pytnon_bkp}")
    shutil.copy("spam.txt", f"c:\\{arquivos_python}")
    shutil.copy("spam.txt", "c:\\arquivos_python\\spam2.txt")
    shutil.copytree(arquivos_python, arquivos_pytnon_bkp)
    for nome_arquivo in os.listdir(f"c:\\{arquivos_python}"):
        os.unlink(f"c:\\{arquivos_python}\\{nome_arquivo}")


def move_para_lixeira():
    nome_arquivo = "./arquivo.txt"
    with open(nome_arquivo, "w") as arquivo:
        arquivo.write("teste")

    send2trash(nome_arquivo)


def arvore_diretorio():
    for nome_pasta, pastas, arquivos in os.walk(os.getcwd()):
        print(nome_pasta)


if __name__ == '__main__':
    # copia_move_deleta()
    # move_para_lixeira()
    # arvore_diretorio()
    # lista_arquivo_zip()
    # extrai_todos_arquivos()
    # extrai_um_arquivo()
    cria_arquivo_zip()
