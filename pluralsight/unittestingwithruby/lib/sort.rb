module Sort
    def self.quicksort(arr, left, right)
        if left >= right
            return
        end

        pivot = arr[(left + right) / 2]

        index = self.partition(arr, left, right, pivot)

        self.quicksort(arr, left, index - 1)

        self.quicksort(arr, index, right)
    end

    def self.partition(arr, left, right, pivot)
        if left <= right
            while arr[left] < pivot
                left += 1
            end

            while arr[right] > pivot
                right -= 1
            end

            if left <= right
                self.swap(arr, left, right)
                left += 1
                right -= 1
            end
        end

        left
    end

    def self.swap(arr, i, j)
        arr[i], arr[j] = arr[j], arr[i]
    end
end
