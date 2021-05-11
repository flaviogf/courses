class Book
    def title=(value)
        @title = value
    end
end

book = Book.new

book.title = 'Harry Potter and the Chamber of Secrets'

class Book
    def title
        @title
    end
end

puts book.title
