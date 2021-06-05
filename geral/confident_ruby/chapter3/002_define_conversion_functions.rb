module Graphics
  module Conversions
    module_function

    def Point(*args)
      case args.first
      when Integer then Point.new(*args)
      when String then Point.new(*args.first.split(':').map(&:to_i))
      when ->(arg) { arg.respond_to?(:to_point) }
        args.first.to_point
      when ->(arg) { arg.respond_to?(:to_ary) } 
        Point.new(*args.first.to_ary)
      else
        raise TypeError, "Cannot convert #{args.inspect} to Point"
      end
    end

    Point = Struct.new(:x, :y) do
      def inspect
        "#{x}:#{y}"
      end

      def to_point
        self
      end
    end

    Pair = Struct.new(:a, :b) do
      def to_ary
        return [a, b]
      end
    end

    class Flag
      def initialize(x, y, flag_color)
        @x, @y, @flag_color = x, y, flag_color
      end

      def to_point
        Point.new(@x, @y)
      end
    end
  end
end

include Graphics
include Graphics::Conversions

puts Point(Point.new(2,3)).inspect
puts Point([9, 7]).inspect
puts Point(3, 5).inspect
puts Point('8:10').inspect
puts Point(Pair.new(23, 32)).inspect
puts Point(Flag.new(42, 24, :red)).inspect
