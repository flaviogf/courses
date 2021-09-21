# frozen_string_literal: true

module Ex26
  Point = Struct.new(:x, :y)

  class Map
    def draw_point(point)
      point.draw_on(self)
    end
  end
end
