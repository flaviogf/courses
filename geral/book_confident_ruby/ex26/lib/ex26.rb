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
  end
end
