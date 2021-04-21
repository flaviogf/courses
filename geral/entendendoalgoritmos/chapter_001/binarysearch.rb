def binary_search(values, target)
  left = 0

  right = values.length - 1

  while left <= right
    mid = (left + right) / 2

    if values[mid] == target
      return true
    elsif values[mid] > target
      right = mid - 1
    else
      left = mid + 1
    end
  end

  return false
end

values = [1, 3, 5, 7, 9]

puts binary_search(values, 7)
