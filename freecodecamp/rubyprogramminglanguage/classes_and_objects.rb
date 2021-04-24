class Book
    attr_accessor :title, :author, :pages

    def initialize(title, author, pages)
        @title = title
        @author = author
        @pages = pages
    end
end

book1 = Book.new("Harry Potter", "JK Rowling", 400)

puts "Title: #{book1.title}, Author: #{book1.author}, Pages: #{book1.pages}"
