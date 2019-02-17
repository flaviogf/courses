import kivy

from kivy.app import App
from kivy.uix.boxlayout import BoxLayout

kivy.require('1.9.1')


class Tela1(BoxLayout):

    def on_press_btn(self):
        janela.root_window.remove_widget(self)
        janela.root_window.add_widget(Tela2())


class Tela2(BoxLayout):

    def on_press_btn(self):
        janela.root_window.remove_widget(self)
        janela.root_window.add_widget(Tela1())


class KivyVsPy2App(App):
    pass


janela = KivyVsPy2App()
janela.run()
