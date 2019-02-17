def main():
    try:
        arquivo = open('arquivo.txt')
    except IOError:
        print('arquivo nao exites')
    else:
        for linha in arquivo.readlines():
            print(linha)
    finally:
        print('Fim '.ljust(100, '='))


if __name__ == '__main__':
    main()
