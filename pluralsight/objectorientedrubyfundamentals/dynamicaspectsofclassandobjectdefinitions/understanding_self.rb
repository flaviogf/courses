class Book
    attr_reader :title

    def initialize(title:)
        @title = title
    end

    def save
        puts "book.save, context: #{self}"
    end

    def self.find
        puts "self.find, context: #{self}"

        Book.new title: 'Harry Potter and the chamber of secrets'
    end
end

def main
    puts "main, context: #{self}"

    book = Book.find
    
    book.save
end

main
