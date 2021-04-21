operations = {:add => lambda {|x,y| x + y}, :sub => lambda {|x,y| x - y}}

print "x: "
x = gets.chomp.to_f
print "y: "
y = gets.chomp.to_f
print "operation (add, sub): "
operation = gets.chomp
puts operations[operation.to_sym].(x, y)
