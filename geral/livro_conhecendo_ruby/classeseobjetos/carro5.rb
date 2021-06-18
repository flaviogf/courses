class Carro
  def initialize(marca, modelo, cor, tanque)
  end
end

class Carro
  def novo_metodo
    puts 'Novo metodo'
  end
end

corsa = Carro.new(:chevrolet, :corsa, :preto, 50)

corsa.novo_metodo
