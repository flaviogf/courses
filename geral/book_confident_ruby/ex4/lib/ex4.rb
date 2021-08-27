# frozen_string_literal: true

module Ex4
  Place = Struct.new(:index, :name, :prize) do
    def to_i
      index
    end

    def to_s
      name
    end
  end
end
