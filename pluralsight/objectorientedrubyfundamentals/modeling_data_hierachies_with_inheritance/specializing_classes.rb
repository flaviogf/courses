class Collection
end

class Series < Collection
end

class Books < Collection
end

puts Books.superclass
puts Books.superclass.superclass
puts Books.superclass.superclass.superclass
puts Books.superclass.superclass.superclass.superclass
