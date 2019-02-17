numero_secreto=175
numero_tentativas=3
puts "Nome:"
nome = gets
puts "Bem Vindo: " + nome

for tentativa in 1..numero_tentativas
	puts "Tentativa #{tentativa} de #{numero_tentativas}"
	puts "Digite um numero:"
	chute = gets
	acertou = chute.to_i == numero_secreto

	if acertou
		puts "Acertou"
                break
	else
		puts "Errou"
	end
end
