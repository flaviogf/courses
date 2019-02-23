import os
from unittest import TestCase

from app.tocador import Tocador


class TestTocador(TestCase):
    def test_tocador_init(self):
        tocador = Tocador(diretorio='audios', arquivo='ola.mp3')

        self.assertEqual('audios', tocador.diretorio)
        self.assertEqual('ola.mp3', tocador.arquivo)

    def test_tocador_salva_audio(self):
        tocador = Tocador(diretorio='audios', arquivo='ola.mp3')

        audio = tocador.salva_audio(audio='Olá mundo!', linguagem='pt-br')

        self.assertTrue(os.path.isfile(audio))
