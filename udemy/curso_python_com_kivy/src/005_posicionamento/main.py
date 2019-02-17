from kivy.app import App
from kivy.uix.floatlayout import FloatLayout


class Root(FloatLayout):
    pass


class Posicionamento(App):

    def build(self):
        return Root()


if __name__ == '__main__':
    Posicionamento().run()
