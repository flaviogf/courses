require_relative 'wrapper'

str = 'X' * 1024 * 1024 * 10 # 10 MB string

measure do
  str = str.downcase
end

measure do
  str.downcase!
end
