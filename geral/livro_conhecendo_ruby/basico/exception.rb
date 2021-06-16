def sample_1
  numero = 1
  string = "oi"
  numero + string
rescue StandardError => exception
  puts "Ocorreu um erro: #{exception}"
end

def sample_2
  numero = 1
  string = "oi"
  numero + string
rescue => exception
  puts "Ocorreu um erro do tipo #{exception.class}"
end

def sample_3
  numero = 1
  string = "oi"
  numero + string
rescue => exception
  puts "Ocorreu um erro do tipo #{exception.class}"
ensure
  puts "Lascou tudo"
end

def sample_4
  numero = 1
  string = "oi"
  numero + string
rescue => exception
  puts "Ocorreu um erro do tipo #{exception.class}"
  puts msg
ensure
  puts "Lascou tudo"
end

def sample_5(n1, n2)
  puts n1 + n2
rescue => exception
  puts "Ocorreu um erro #{exception}"
  n2 = 1
  retry
end

sample_1
sample_2
sample_3
# sample_4
sample_5 1, "oi"
