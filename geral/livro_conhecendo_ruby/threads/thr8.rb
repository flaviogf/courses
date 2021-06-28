# frozen_string_literal: true

items = []
lock = Mutex.new
cond = ConditionVariable.new
limit = 0

producer = Thread.new do
  loop do
    lock.synchronize do
      quantity = rand(50)

      next if quantity.zero?

      puts "producing #{quantity} item(s)"

      items = Array.new(quantity, 'item')

      cond.wait(lock)

      puts 'consumed'

      puts '-' * 25

      limit += 1
    end

    break if limit > 5
  end
end

consumer = Thread.new do
  loop do
    lock.synchronize do
      unless items.empty?
        puts "consuming #{items.length} item(s)"
        items = []
      end

      cond.signal
    end
  end
end

producer.join
