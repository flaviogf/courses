File.open "teste.txt" do |file|
  file.each_char do |c|
    print "[#{c}]"
  end
end
