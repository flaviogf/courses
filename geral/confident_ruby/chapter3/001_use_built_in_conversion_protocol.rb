Place = Struct.new(:index, :name, :prize) do
  def to_int
    index
  end
end

first = Place.new(0, 'first', 'Peasant\' Quest game')

second = Place.new(1, 'second', 'Limozeen Album')

third = Place.new(2, 'third', 'Butter-da')

winners = [
  'Homestart',
  'King of Town',
  'Marzipan',
  'Strongbad'
]

[first, second, third].each do |place|
  puts "In #{place.name} place, #{winners[place]}!"
  puts "You win: #{place.prize}"
end
