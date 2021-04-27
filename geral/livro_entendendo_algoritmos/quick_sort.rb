def main()
    values = load

    quicksort(values, 0, values.size - 1)

    puts values
end

def load()
    values = []

    IO.foreach("unsorted.txt") { |line| values.push line.to_i }

    values
end

def quicksort(values, left, right)
    if left >= right
        return
    end

    pivot = values[(left + right) / 2]

    index = partition(values, left, right, pivot)

    quicksort(values, left, index - 1)

    quicksort(values, index, right)
end

def partition(values, left, right, pivot)
    while left <= right
        while values[left] < pivot
            left += 1
        end

        while values[right] > pivot
            right -= 1
        end

        if left <= right
            swap(values, left, right)
            left += 1
            right -= 1
        end
    end

    left
end

def swap(values, i, j)
    values[i], values[j] = values[j], values[i]
end

main
