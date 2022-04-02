require_relative 'wrapper'

data = Array.new(100) { 'x' * 1024 * 1024 }

measure do
  data = data.map(&:upcase!)
end
