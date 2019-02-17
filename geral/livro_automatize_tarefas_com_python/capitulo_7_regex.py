import re


def main():
    # testa_telefone()
    # testa_pipe()
    # testa_pipe_com_grupos()
    # testa_opcional()
    # testa_asterisco()
    # testa_simbolo_adicao()
    # teste_repeticao()
    # testa_regex_greedy()
    # testa_find_all()
    # teste_classes_e_negacao()
    # testa_inicio_e_fim()
    # testa_quebra_de_linha()
    # testa_caixa_texto()
    # testa_substituicao()
    verifica_senha()


def verifica_senha():
    regex_tamanho_minimo = re.compile(r"[\w\d]{8,}")
    regex_verifica_numero = re.compile(r"\d+")
    regex_verifica_minusculas = re.compile(r"[a-z]+")
    regex_verifica_maisculas = re.compile(r"[A-Z]+")
    senha = input("digite um senha: ")
    tamanho_minimo = regex_tamanho_minimo.search(senha)
    possui_numero = regex_verifica_numero.search(senha)
    possui_letras_minusculas = regex_verifica_minusculas.search(senha)
    possui_letras_maisculas = regex_verifica_maisculas.search(senha)
    if tamanho_minimo is not None \
            and possui_letras_minusculas is not None \
            and possui_numero is not None \
            and possui_letras_maisculas is not None:
        print(f"senha {senha} forte")
    else:
        print(f"senha {senha} fraca")


def testa_substituicao():
    regex = re.compile(r"Agente \w+")
    resultado = regex.sub("CENSORED", "Agente Teste teste teste Agente Teste teste")
    print(resultado)
    regex2 = re.compile(r"Agente (\w)(\w)\w*")
    resultado2 = regex2.sub(r"\2 *** \1", "Agente teste teste teste")
    print(resultado2)
    regex3 = re.compile(
        r"""
        (\w){6}
        """, re.VERBOSE)
    resultado3 = regex3.sub("**", "flavio garcia fernandes")
    print(resultado3)


def testa_caixa_texto():
    regex = re.compile(r"teste", re.IGNORECASE)
    resultado = regex.findall("TESTE teste")
    print(resultado)


def testa_quebra_de_linha():
    regex1 = re.compile(".*")
    resultado = regex1.search("teste \n teste")
    print(resultado.group())
    regex2 = re.compile(".*", re.DOTALL)
    resultado2 = regex2.search("teste \n teste \n teste")
    print(resultado2.group())


def testa_inicio_e_fim():
    regex = re.compile(r"^Hello")
    resultado = regex.search("Hello teste")
    print(resultado.group())
    regex2 = re.compile(r"^Hello$")
    mo1 = regex2.search("Hello")
    mo2 = regex2.search("Hello teste")
    print(mo1 is not None)
    print(mo2 is not None)


def teste_classes_e_negacao():
    regex2 = re.compile(r"[^aeiouAEIOU]")
    resultado2 = regex2.findall("flavio")
    print("".join(resultado2))
    regex = re.compile(r"[aeiouAEIOU]")
    resultado = regex.findall("flavio")
    print("".join(resultado))


def testa_find_all():
    regex = re.compile(r"\d\d\d\d-\d\d\d\d")
    resultado_string = regex.findall("1234-1234 teste 1234-1234")
    print(resultado_string)
    regex2 = re.compile(r"(\d\d\d)-(\d\d\d)")
    resultado_tupla = regex2.findall("123-123 testnado 123-123")
    print(resultado_tupla)


def testa_regex_greedy():
    regex1 = re.compile("(ha){3,5}")  # greedy gulosa
    mo1 = regex1.search("hahahaha")
    print(mo1.group())
    regex2 = re.compile("(ha){3,5}?")  # nongreedy nao gulosa
    mo2 = regex2.search("hahahaha")
    print(mo2.group())


def teste_repeticao():
    regex = re.compile(r"(HA){3}")
    mo1 = regex.search("HAHAHA")
    mo2 = regex.search('HA')
    if mo1 is not None:
        print(mo1.group())
    if mo2 is None:
        print("não segue o padrao")


def testa_simbolo_adicao():
    regex = re.compile(r"bat(wo)+man")
    resultado = regex.search("batman")
    if resultado is None:
        print("deu certo")
    else:
        print(resultado.group())


def testa_asterisco():
    regex = re.compile(r"bat(wo)*man")
    resultado = regex.search("batwowowowoman")
    if resultado is not None:
        print(resultado.group())
        print(resultado.group(1))


def testa_opcional():
    regex = re.compile(r"bat(wo)?man")
    resutado = regex.search("batman")
    if resutado is not None:
        print(resutado.group())
    resutado = regex.search("batwoman")
    if resutado is not None:
        print(resutado.group())


def testa_pipe_com_grupos():
    regex = re.compile(r"bat(man|mobile|carro)")
    resultado = regex.search("batman teste")
    if resultado is not None:
        print(resultado.group(1))
        print(resultado.group())


def testa_pipe():
    regex = re.compile(r"batman|flavio")
    resultado = regex.search("batman teste flavio")
    if resultado is not None:
        print(resultado.group())


def testa_telefone():
    regex = re.compile(r"(\d{3})-(\d{3}-\d{4})")
    resultado = regex.search("123-123-1234")
    if resultado is not None:
        print(resultado.group(1))
        print(resultado.group(2))
        print(resultado.group())
        print(resultado.groups())


if __name__ == '__main__':
    main()
