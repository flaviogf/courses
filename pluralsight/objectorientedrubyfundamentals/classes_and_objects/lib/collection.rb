class Collection
    attr_reader :name

    def initialize(name:)
        @name = name
        @books = []
    end

    def <<(book)
        @books << book
    end

    def [](index)
        @books[index]
    end
end
