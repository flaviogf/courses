# frozen_string_literal: true

module Ex12
  module Graphics
    module Conversions
      module_function

      def Point(*args)
        case args.first
        when Point then args.first
        when Array then Point.new(*args.first)
        end
      end
    end

    Point = Struct.new(:x, :y)
  end
end
