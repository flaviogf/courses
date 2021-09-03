# frozen_string_literal: true

require_relative 'test_helper'

module Ex14
  class TraficLight
    class StopTest < MiniTest::Test
      def setup
        @stop = Stop.new
      end

      def test_to_s
        assert_equal('stop', @stop.to_s)
      end

      def test_name
        assert_equal('stop', @stop.name)
      end

      def test_color
        assert_equal('red', @stop.color)
      end

      def test_next_state
        assert_instance_of(Proceed, @stop.next_state)
      end
    end

    class CautionTest < MiniTest::Test
      def setup
        @caution = Caution.new
      end

      def test_to_s
        assert_equal('caution', @caution.to_s)
      end

      def test_name
        assert_equal('caution', @caution.name)
      end

      def test_color
        assert_equal('yellow', @caution.color)
      end

      def test_next_state
        assert_instance_of(Stop, @caution.next_state)
      end
    end

    class ProceedTest < MiniTest::Test
      def setup
        @proceed = Proceed.new
      end

      def test_to_s
        assert_equal('proceed', @proceed.to_s)
      end

      def test_name
        assert_equal('proceed', @proceed.name)
      end

      def test_color
        assert_equal('green', @proceed.color)
      end

      def test_next_state
        assert_instance_of(Caution, @proceed.next_state)
      end
    end
  end
end
