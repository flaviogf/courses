require_relative 'wrapper'

measure do
  File.readlines('output.txt').map! { |line| line.split(',') }
end
