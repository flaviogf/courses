require_relative 'wrapper'

measure do
  x = 'X' * 1024 * 1024 * 10
  x += ('Y' * 1024 * 1024 * 10)
end

measure do
  x = 'X' * 1024 * 1024 * 10
  x << ('Y' * 1024 * 1024 * 10)
end
