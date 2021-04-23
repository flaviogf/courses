File.open("names.txt", "r") do |file|
    file.each { |line| puts line}
end
