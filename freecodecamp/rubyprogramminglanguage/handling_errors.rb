begin
    puts "10" + 0
    puts 10 / 0
rescue ZeroDivisionError => e
    puts e
rescue TypeError
    puts "You cannot do it"
end
