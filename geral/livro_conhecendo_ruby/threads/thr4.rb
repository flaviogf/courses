# frozen_string_literal: true

min = 0

max = 0

log = 0

Thread.new do
  loop do
    min -= 1
    max += 1
  end
end

Thread.new do
  loop do
    log = min + max
  end
end

sleep 3

puts "log value #{log}"
