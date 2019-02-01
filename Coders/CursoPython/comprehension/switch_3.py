#!/usr/local/bin/python3


def get_dia_semana(dia):
    dias = {(1, 7): 'Fim de semana', tuple(range(2, 7)): 'Dia de semana'}
    dia_escolhido = (tipo for numero, tipo in dias.items() if dia in numero)
    return next(dia_escolhido, '**-- dia invalido --**')


if __name__ == '__main__':
    for it in range(9):
        print(get_dia_semana(it))
