require_relative 'speaker'

class Anglophone < Speaker
  def speak
    puts "Hello, my name is #{@name}"
  end
end

Anglophone.new('Jack').speak
