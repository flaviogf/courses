module Factorial
    def self.recursive(n)
        if n > 1
            n * self.recursive(n - 1)
        else
            1
        end
    end

    def self.iterative(n)
        binding.irb

        result = 1

        (2..n).each do |i|
            result *= i
        end

        result
    end
end
