import kivy

from kivy.uix.button import Button
from kivy.uix.boxlayout import BoxLayout

from kivy.app import App
from kivy.lang.builder import Builder

kivy.require('1.9.1')

code = """
Button:
    text: 'OK'
"""


class KeywordsKivyApp(App):

    def build(self):
        return Builder.load_string(code)


KeywordsKivyApp().run()
