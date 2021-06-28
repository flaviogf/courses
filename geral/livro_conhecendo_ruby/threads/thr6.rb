# frozen_string_literal: true

require 'monitor'

min = 0

max = 0

log = 0

mutex = Monitor.new

Thread.new do
  loop do
    mutex.synchronize do
      min -= 1
      max += 1
    end
  end
end

Thread.new do
  loop do
    mutex.synchronize do
      log = min + max
    end
  end
end

sleep 3

puts "log value #{log}"
