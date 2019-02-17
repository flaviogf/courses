from kivy.app import App
from kivy.uix.button import Button


class Hello(App):

    def build(self):
        return Button(text="Hello World")


Hello().run()
