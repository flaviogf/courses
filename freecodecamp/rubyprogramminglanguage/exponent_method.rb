def pow(base_number, pow_number)
    result = 1

    pow_number.times { result *= base_number }
    
    result
end

10.times { |i| puts pow(2, i) }
