if __name__ == '__main__':
    from random import shuffle, sample
    import os

    diretorio_de_trabalho = "c:\\arquivos_python"

    if not os.path.exists(diretorio_de_trabalho):
        os.makedirs(diretorio_de_trabalho)

    os.chdir(diretorio_de_trabalho)

    estados_capitais = {
        'sao paulo': 'sao paulo',
        'rio de janeiro': 'rio de janeiro',
        'espirito santo': 'vitoria'
    }
    estados = list(estados_capitais.keys())
    capitais = list(estados_capitais.values())

    quantidade_de_perguntas = len(estados_capitais.keys()) - 1
    quantidade_de_provas = 35

    for i in range(quantidade_de_provas):
        shuffle(estados)
        with open(f"prova{i}.txt", "w") as arquivo_prova:
            arquivo_prova.write("Nome:\n\n")
            arquivo_prova.write("Data:\n\n")
            arquivo_prova.write("Prova de capitais de estados".center(50, "="))

        with open(f"gabarito{i}.txt", "w") as arquivo_gabarito:
            arquivo_gabarito.write("Gabarito".center(50, "="))

    for numero_questao in range(quantidade_de_perguntas):
        correta = estados_capitais[estados[numero_questao]]
        erradas = list(filter(lambda x: x != correta, estados_capitais.values()))
        erradas = sample(erradas, 1)
        opcoes = erradas + [correta]
        for i in range(quantidade_de_provas):
            shuffle(opcoes)
            with open(f"prova{i}.txt", "a") as arquivo_prova:
                arquivo_prova.write(f"\n\nQual é a capital do estado {estados[numero_questao]} ?\n\n")
                for indice, valor in enumerate(opcoes):
                    arquivo_prova.write(f"{indice} {valor}\n")

            with open(f"gabarito{i}.txt", "a") as arquivo_gabarito:
                arquivo_gabarito.write(f"\n\n{numero_questao} - {correta}")
