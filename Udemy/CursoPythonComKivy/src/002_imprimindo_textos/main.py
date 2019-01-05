from kivy.app import App
from kivy.uix.label import Label


class Root(App):

    def build(self):
        return Label(text="Python com kivy", italic=True, font_size=50)


if __name__ == '__main__':
    Root().run()
