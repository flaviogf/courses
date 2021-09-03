# frozen_string_literal: true

module Ex12
  module Graphics
    module Conversions
      module_function

      def Point(*args)
        case args.first
        when Point then args.first
        when Array then Point.new(*args.first)
        when Integer then Point.new(*args)
        when String then Point.new(*args.first.split(':').map(&:to_i))
        else raise TypeError, "Cannot convert #{args.inspect} to Point"
        end
      end
    end

    Point = Struct.new(:x, :y)
  end
end
