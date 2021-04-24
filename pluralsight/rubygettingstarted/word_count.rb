#!/usr/local/bin/ruby

FILE_NAME = "romeo-juliet.txt"

def words_from_file(file_name)
  File.read(file_name).downcase.gsub(/[^a-z]/, " ").split
end

words = words_from_file(FILE_NAME)

words_count = {}

words.each do |word|
  words_count[word] = 0 unless words_count[word]
  words_count[word] += 1
end

