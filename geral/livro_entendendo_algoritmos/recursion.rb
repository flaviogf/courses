def main()
    puts factorial(5)

    puts fibonacci(5)
end

def factorial(n)
    if n >= 2
        return n * factorial(n-1)
    end
    
    return 1
end

def fibonacci(n)
    if n >= 3
        return fibonacci(n - 1) + fibonacci(n - 2)
    end

    return 1
end

main
