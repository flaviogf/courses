import kivy
from kivy.app import App
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.button import Button

kivy.require('1.9.1')


class Tela1(BoxLayout):

    def __init__(self, **kwargs):
        super().__init__(**kwargs)
        self.orientation = 'vertical'
        btn1 = Button(text='Botão 1', on_press=self.on_press_btn)
        self.add_widget(btn1)
        self.add_widget(Button(text='bt1'))
        self.add_widget(Button(text='bt2'))

    def on_press_btn(self, event):
        janela.root_window.remove_widget(self)
        janela.root_window.add_widget(Tela2())


class Tela2(BoxLayout):

    def __init__(self, **kwargs):
        super().__init__(**kwargs)
        self.orientation = 'vertical'
        btn2 = Button(text="Botão 2", on_press=self.on_press_btn)
        self.add_widget(btn2)

    def on_press_btn(self, event):
        janela.root_window.remove_widget(self)
        janela.root_window.add_widget(Tela1())


class KivyVsPyApp(App):

    def build(self):
        return Tela1()


janela = KivyVsPyApp()
janela.run()
