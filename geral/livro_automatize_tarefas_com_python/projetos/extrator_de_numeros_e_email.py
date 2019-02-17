from pyperclip import copy, paste

import re


def main():
    dados = paste()
    regex_telefone = re.compile("(\+\d\s)?(\d){3}\.(\d){3}\.(\d){4}")
    regex_email = re.compile("(\w)*@(\w)*\.(\w)*")
    telefones = regex_telefone.finditer(dados)
    emails = regex_email.finditer(dados)
    dados_fitrados = ""
    for telefone in telefones:
        dados_fitrados += f"{telefone.group()}\n"
    for email in emails:
        dados_fitrados += f"{email.group()}\n"
    copy(dados_fitrados)
    print("dados filtrados foram copiados")
    print(dados_fitrados)


if __name__ == '__main__':
    main()
