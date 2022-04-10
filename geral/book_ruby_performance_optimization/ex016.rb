require 'date'
require 'ruby-prof'

GC.disable

result = RubyProf.profile do
  Date.parse('2014-07-01')
end

RubyProf::FlatPrinter.new(result).print(File.open('ruby_prof_ex016_profile.txt', mode: 'w'))
