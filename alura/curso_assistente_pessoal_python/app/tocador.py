import os

from gtts import gTTS


class Tocador:
    def __init__(self, diretorio, arquivo):
        self.diretorio = diretorio
        self.arquivo = arquivo

    def salva_audio(self, audio, linguagem='pt-br'):
        if not os.path.isdir(self.diretorio):
            os.mkdir(self.diretorio)

        caminho_audio = os.path.join(os.getcwd(), self.diretorio, self.arquivo)
        tts = gTTS(audio, lang=linguagem)
        tts.save(caminho_audio)
        return caminho_audio
