# frozen_string_literal: true

module Ex27
  Point = Struct.new(:x, :y, :name, :magnitude)

  class Map
    def draw_point(point)
      point.draw_on(self)
    end
  end
end
