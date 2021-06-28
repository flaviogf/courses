# frozen_string_literal: true

fib = Fiber.new do
  x = 0

  y = 1

  loop do
    Fiber.yield y

    x, y = y, x + y
  end
end

10.times { puts fib.resume }
