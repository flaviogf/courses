require 'date'
require 'book'

RSpec.describe Book do
    it 'should have a title, an author and a publish date' do
        book = Book.new title: 'Book#1', author: 'JK Rowling', pub_date: Date.new(2000, 1, 1)

        expect(book.title).to eq('Book#1')
        expect(book.author).to eq('JK Rowling')
        expect(book.pub_date).to eq(Date.new(2000, 1, 1))
    end
end
