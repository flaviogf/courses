def fib(n)
  a, b = 1, 1
  while a < n
    puts a
    a, b = b, a + b
  end
end

fib(42)
