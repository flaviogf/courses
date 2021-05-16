def gets_name(&block)
  puts 'Enter your name'
  name = gets.chomp
  block.call(name)
end

gets_name { |name| puts "Hello, #{name}" }

