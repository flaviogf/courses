class Impressao:

    def imprime(self):
        print(self)


class Programa:

    def __init__(self, nome: str, ano: int):
        self._nome = nome
        self._ano = ano
        self._likes = 0

    @property
    def nome(self):
        return self._nome.title()

    @property
    def ano(self):
        return self._ano

    @property
    def likes(self):
        return self._likes

    def dah_like(self):
        self._likes += 1

    def __str__(self):
        return f'Nome: {self.nome} - Ano: {self.ano} - Likes: {self.likes}'


class Filme(Programa, Impressao):

    def __init__(self, nome: str, ano: int, duracao: float):
        super(Filme, self).__init__(nome, ano)
        self._duracao = duracao

    @property
    def duracao(self):
        return self._duracao

    def __str__(self):
        return f'Nome: {self.nome} - Ano: {self.ano} - Duracao: {self.duracao} - Likes: {self.likes}'


class Serie(Programa, Impressao):

    def __init__(self, nome: str, ano: int, temporadas: int):
        super(Serie, self).__init__(nome, ano)
        self._temporadas = temporadas

    @property
    def temporadas(self):
        return self._temporadas

    def __str__(self):
        return f'Nome: {self.nome} - Ano: {self.ano} - Temporadas: {self.temporadas} - Likes: {self.likes}'


class Playlist:

    def __init__(self, nome: str, *programas):
        self._nome = nome
        self._programas = list(programas)

    @property
    def nome(self):
        return self._nome

    def __getitem__(self, item):
        return self._programas[item]

    def __len__(self):
        return len(self._programas)


vingadores = Filme('vingadores', 2018, 160)
vingadores.dah_like()
vingadores.dah_like()

flash = Serie("Flash", 2014, 10)
flash.dah_like()
flash.dah_like()
flash.dah_like()

playlist_final_de_semana = Playlist("final de sema", vingadores, flash)

print(f'Tamanho da playlist: {len(playlist_final_de_semana)}\n')

for programa in playlist_final_de_semana:
    programa.imprime()
