from pyperclip import copy, paste


def main():
    text_copiado = paste()
    lista = text_copiado.split('\n')
    lista = list(map(lambda item: f'* {item}', lista))
    texto_formatado = '\n'.join(lista)
    copy(texto_formatado)
    print("lista formatada foi copiada")
    print(texto_formatado)


if __name__ == '__main__':
    main()
