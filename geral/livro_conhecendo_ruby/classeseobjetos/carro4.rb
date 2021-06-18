class Carro
  attr_reader :cor
  attr_writer :cor

  def initialize(marca, modelo, cor, tanque)
    @marca = marca
    @modelo = modelo
    @cor = cor
    @tanque = tanque
  end
end

carro = Carro.new(:chevrolet, :corsa, :preto, 50)

carro.cor = :prata

puts carro.cor
