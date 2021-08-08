# frozen_string_literal: true

from_file, to_file = ARGV

puts "Copying from #{from_file} to #{to_file}"

open(from_file) do |in_file|
  in_data = in_file.read

  puts "The input file is #{in_data.length} bytes long"

  puts "Does the output file exist? #{File.exist?(to_file)}"
  puts 'Ready, hit RETURN to continue, CTRL-c to abort.'
  $stdin.gets

  open(to_file, 'w') do |out_file|
    out_file.write(in_data)
  end

  puts 'Alright, all done.'
end
