# frozen_string_literal: true

module Ex25
  def self.break_words(stuff)
    stuff.split(' ')
  end

  def self.sort_words(words)
    words.sort
  end

  def self.print_first_word(words)
    puts words.first
  end

  def self.print_last_word(words)
    puts words.pop
  end

  def self.sort_sentence(sentence)
    words = break_words(sentence)
    sort_words(words)
  end

  def self.print_first_and_last(sentence)
    words = break_words(sentence)
    print_first_word(words)
    print_last_word(words)
  end

  def self.print_first_and_last_sorted(sentence)
    words = sort_sentence(sentence)
    print_first_word(words)
    print_last_word(words)
  end
end
