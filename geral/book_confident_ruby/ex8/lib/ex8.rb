# frozen_string_literal: true

module Ex8
  class << self
    def draw_line(start, endpoint)
      start = start.to_coords if start.respond_to?(:to_coords)
      start = start.to_ary
      endpoint = endpoint.to_coords if endpoint.respond_to?(:to_coords)
      endpoint = endpoint.to_ary

      puts start.inspect
      puts endpoint.inspect
    end
  end

  class Point
    attr_reader :x, :y, :name

    def initialize(x, y, name = nil)
      @x = x
      @y = y
      @name = name
    end

    def to_coords
      [x, y]
    end
  end
end
