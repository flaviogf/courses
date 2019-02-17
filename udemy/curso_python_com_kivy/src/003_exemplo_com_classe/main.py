from kivy.app import App
from kivy.uix.button import Button


class Aplicacao(App):

    def build(self):
        return Button(text="Ação", on_press=self.clique_botao)

    @staticmethod
    def clique_botao(botao):
        print(f"{botao.__class__.__name__} pressionado")


if __name__ == '__main__':
    Aplicacao().run()
