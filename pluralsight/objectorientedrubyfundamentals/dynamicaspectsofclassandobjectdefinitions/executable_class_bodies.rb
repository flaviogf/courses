res = class Book
    puts "Books' definition"
    123
end

puts res

class BookForm
    def self.validates(attr, rules)
        @validations ||= Hash.new
        @validations[attr] = rules
    end

    def is_valid?
        BookForm.validations.each_pair {|key,value| puts key,value}
        true
    end

    def self.validations
        @validations
    end
end

class BookForm
    attr_reader :title, :pages

    validates :title, presence: true, uniqueness: true

    validates :pages, presence: true, min: 1

    def initialize(title:, pages:)
        @title = title
        @pages = pages
    end
end

form = BookForm.new title: 'Harry Potter and the Chamber of Secrets', pages: 384

puts "Title: #{form.title}, Pages: #{form.pages}"

puts form.is_valid?
