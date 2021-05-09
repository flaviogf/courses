require 'date'
require 'collection'
require 'book'

RSpec.describe Collection do
    it 'should have a name' do
        collection = Collection.new name: 'Best sellers'

        expect(collection.name).to eq('Best sellers')
    end

    it 'should be able to retrive an added book' do
        collection = Collection.new name: 'Best sellers'

        book1 = Book.new title: 'Book#1', author: 'JK Rowling', pub_date: Date.new(2000, 1, 1)

        collection << book1

        expect(collection[0]).to eq(book1)
    end
end
