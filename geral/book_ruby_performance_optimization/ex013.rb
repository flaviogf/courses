require_relative 'wrapper'

measure do
  File.open('output.txt', mode: 'r') do |f|
    while (line = f.gets)
      line.split(',')
    end
  end
end
