def get_input
  puts 'Digite algo: (número termina)'
  resp = gets
  throw :end_of_response, resp if resp.chomp =~ /^\d+$/
end

num = catch(:end_of_response) do
  while true
    get_input
  end
end

puts "Terminando com: #{num}"
