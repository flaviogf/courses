class Book
    attr_reader :title, :author, :pub_date

    def initialize(title:, author:, pub_date:)
        @title = title
        @author = author
        @pub_date = pub_date
    end
end
