class Carro
  class << self
    attr_accessor :qtde
  end

  @qtde = 0


  def initialize(marca, modelo, cor, tanque)
    @marca = marca
    @modelo = modelo
    @cor = cor
    @tanque = tanque
    self.class.qtde += 1
  end
end

Carro.new :chevrolet, :corsa, :preto, 50
Carro.new :chevrolet, :corsa, :preto, 50
Carro.new :chevrolet, :corsa, :preto, 50

puts Carro.qtde
