class Carro:
    def __init__(self, velocidade_maxima):
        self.velocidade_maxima = velocidade_maxima
        self.velocidade_atual = 0

    def acelera(self, delta=5):
        nova_velocidade = self.velocidade_atual + delta

        self.velocidade_atual = nova_velocidade \
            if nova_velocidade < self.velocidade_maxima \
            else self.velocidade_maxima

        return self.velocidade_atual

    def freia(self, delta=5):
        nova_velocidade = self.velocidade_atual - delta

        self.velocidade_atual = nova_velocidade \
            if nova_velocidade > 0 \
            else 0

        return self.velocidade_atual
