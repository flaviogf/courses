# frozen_string_literal: true

module Ex14
  class TrafficLight
    class State
      def to_s
        name
      end

      def name
        self.class.name.split('::').last.downcase
      end
    end

    class Stop < State
      def color
        'red'
      end

      def next_state
        Proceed.new
      end
    end

    class Caution < State
      def color
        'yellow'
      end

      def next_state
        Stop.new
      end
    end

    class Proceed < State
      def color
        'green'
      end

      def next_state
        Caution.new
      end
    end

    def change_to(state)
      State(state)
    end

    private

    def State(state)
      case state
      when State then state
      else self.class.const_get(state.to_s.capitalize).new
      end
    end
  end
end
