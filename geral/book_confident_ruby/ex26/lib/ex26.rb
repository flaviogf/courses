# frozen_string_literal: true

module Ex26
  Point = Struct.new(:x, :y) do
    def draw_on(map)
      puts "Drawing on #{map}"
    end
  end

  class Map
    def draw_point(point)
      point.draw_on(self)
    end

    def draw_line(point_x, point_y)
      point_x.draw_on(self)
      point_y.draw_on(self)
    end
  end
end
