File.open "novo_teste.txt", "w" do |file|
  file << File.read("teste.txt")
end
