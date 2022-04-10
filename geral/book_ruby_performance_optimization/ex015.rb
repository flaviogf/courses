require 'date'
require 'ruby-prof'

GC.disable

RubyProf.start

Date.parse('2014-07-01')

result = RubyProf.stop

printer = RubyProf::FlatPrinter.new(result)
printer.print(File.open('ruby_prof_ex015_profile.txt', mode: 'w'))
