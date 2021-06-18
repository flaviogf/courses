class Carro
  attr_reader :marca, :modelo, :cor, :tanque

  @@qtde = 0

  def initialize(marca, modelo, cor, tanque)
    @marca = marca
    @modelo = modelo
    @cor = cor
    @tanque = tanque
    @@qtde += 1
  end

  def self.qtde
    @@qtde
  end
end

Carro.new :chevrolet, :corsa, :preto, 50
Carro.new :chevrolet, :corsa, :preto, 50
Carro.new :chevrolet, :corsa, :preto, 50

puts Carro.qtde
