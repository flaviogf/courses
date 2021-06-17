def diga_oi
  "Oi"
end

def cinco_multiplos(numero)
  (1..5).map { |valor| valor * numero }
end

def oi(nome = 'Forasteiro')
  "Oi #{nome}"
end

def varios(*valores)
  valores.map { |valor| "valor=#{valor}" }
end

def mostra(a:, b: 10)
  "a é igual #{a}, b é igual #{b}"
end

def executa_bloco(valor)
  yield(valor * 3) if block_given?
end

puts diga_oi

puts cinco_multiplos(5)

puts oi("Frank")

puts oi

puts varios(10, 20, 30, 40)

puts mostra(a: 1, b: 10)

puts mostra(a: 20)

executa_bloco(10) { |valor| puts valor }

executa_bloco(20)
