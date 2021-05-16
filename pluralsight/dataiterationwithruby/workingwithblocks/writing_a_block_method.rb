def gets_name
  puts 'Enter your name'
  name = gets.chomp
  yield name
end

gets_name do |name|
  puts "Hello, #{name}"
end
