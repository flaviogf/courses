from tempfile import TemporaryFile
import os

from gtts import gTTS

import speech_recognition as sr

import pygame
pygame.init()


class Tocador:
    def __init__(self, diretorio='audios', arquivo='audio.mp3'):
        self.diretorio = diretorio
        self.arquivo = arquivo
        self._caminho_absoluto = os.path.join(
            os.getcwd(), self.diretorio, self.arquivo)
        self._caminho_relativo = f'{diretorio}/{arquivo}'

    def salva_audio(self, audio, linguagem='pt-br'):
        if not os.path.isdir(self.diretorio):
            os.mkdir(self.diretorio)

        tts = gTTS(audio, lang=linguagem)
        tts.save(self._caminho_absoluto)
        return self._caminho_absoluto

    def escuta_audio(self):
        recognizer = sr.Recognizer()

        with sr.Microphone() as source:
            audio = recognizer.listen(source)

        try:
            audio = recognizer.recognize_google(audio, language='pt-BR')

            self._toca_audio_temp(f'você disse {audio}')

            return audio
        except (sr.UnknownValueError, sr.RequestError):
            audio = 'audio desconhecido'

            self._toca_audio_temp(audio)

            return audio

    def toca_audio(self):
        pygame.mixer.music.load(self._caminho_absoluto)

        pygame.mixer.music.play()

        return self._caminho_absoluto

    def _toca_audio_temp(self, audio, linguagem='pt-br'):
        temp = TemporaryFile()

        tts = gTTS(audio, lang=linguagem)

        tts.write_to_fp(temp)

        temp.seek(0)

        pygame.mixer.music.load(temp)

        pygame.mixer.music.play()
