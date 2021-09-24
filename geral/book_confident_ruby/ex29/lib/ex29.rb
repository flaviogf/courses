# frozen_string_literal: true

module Ex29
  class << self
    def find_words(prefix)
      words.select { |w| w.downcase =~ /\A#{prefix.downcase}/ }
    end

    def words
      File.readlines('words').map(&:chomp)
    end
  end
end
