# frozen_string_literal: true

module Ex13
  module Graphics
    module Conversions
      module_function

      def Point(*args)
        case args.first
        when Integer then Point.new(*args)
        when String then Point.new(*args.first.split(':').map(&:to_i))
        when ->(arg) { arg.respond_to?(:to_point) } then args.first.to_point
        when ->(arg) { arg.respond_to?(:to_ary) } then Point.new(*args.first.to_ary)
        end
      end
    end

    Point = Struct.new(:x, :y) do
      def to_point
        self
      end
    end

    Flag = Struct.new(:x, :y, :flag_color) do
      def to_point
        Point.new(:x, :y)
      end
    end

    Pair = Struct.new(:a, :b) do
      def to_ary
        [a, b]
      end
    end
  end
end
