def main()
    values = load

    values = selectionSort values

    puts values
end

def load()
    values = []

    IO.foreach("unsorted.txt") { |line| values.push line.to_i }

    values
end

def selectionSort(values)
    sorted_list = []

    while values.size != 0
        lowest_value, lowest_index = lowest values

        sorted_list.push lowest_value

        values.delete_at lowest_index
    end

    return sorted_list
end

def lowest(values)
    lowest_value, lowest_index = values[0], 0

    values.each_with_index do |value, index|
        if lowest_value > value
            lowest_value, lowest_index = value, index
        end
    end

    return lowest_value, lowest_index
end

main
