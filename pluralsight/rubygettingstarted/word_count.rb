#!/usr/local/bin/ruby

FILE_NAME = "romeo-juliet.txt"

def words_from_file(file_name)
  File.open(file_name).read.downcase.gsub(/[^a-z]/, "").split
end

words = words_from_file(FILE_NAME)
