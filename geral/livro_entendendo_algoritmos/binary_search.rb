def main()
    values = load()
    
    result = binary_search(values, 9773)

    puts result
end

def load()
    values = []

    IO.foreach("sorted.txt") do |line|
        values.push line.to_i
    end

    return values
end

def binary_search(values, target)
    left = 0

    right = values.size - 1

    while left <= right
        mid = (left + right) / 2

        if values[mid] == target
            return mid
        elsif values[mid] < target
            left = mid + 1
        else
            right = mid - 1
        end
    end

    return -1
end

main
