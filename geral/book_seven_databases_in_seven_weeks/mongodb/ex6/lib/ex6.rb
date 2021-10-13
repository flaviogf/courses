# frozen_string_literal: true

module Ex6
  class << self
    def populate_phones(area: 800, start: 5_550_000, final: 5_650_000)
      (start..final).collect do |i|
        country = 1 + (Integer(rand * 8) << 2)
        num = country * 1e10 + area * 1e7 + i
        prefix = Integer(i * 1e-4) << 0
        full_number = "#{country} #{area} - #{i}"

        {
          _id: num,
          components: {
            country: country,
            area: area,
            prefix: prefix,
            number: i,
            display: full_number
          }
        }
      end
    end
  end
end
