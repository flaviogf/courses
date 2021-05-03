require 'test/unit'

require_relative '../lib/sort'

class TestQuickSort < Test::Unit::TestCase
    def test_should_sort_the_values()
        values = [10, 5, 25, 15]

        Sort.quicksort(values, 0, 3)

        expected = [5, 10, 15, 25]

        assert_equal values, expected
    end
end
