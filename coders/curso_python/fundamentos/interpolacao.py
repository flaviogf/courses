from string import Template

nome, idade = 'flavio', 21
print('Nome: %s, Idade: %d' % (nome, idade))
print('Nome: {}, Idade: {}'.format(nome, idade))
print(f'Nome: {nome}, Idade: {idade}')
template = Template('Nome: $nome, Idade: $idade')
print(template.substitute(nome=nome, idade=idade))
