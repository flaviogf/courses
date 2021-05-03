require 'test/unit'

require_relative '../lib/factorial.rb'

class TestRecursive < Test::Unit::TestCase
    def test_should_return_120()
        got = Factorial.recursive(5)

        expected = 120

        assert_equal got, expected
    end

    def test_should_return_5040()
        got = Factorial.recursive(7)

        expected = 5040

        assert_equal got, expected
    end
end
