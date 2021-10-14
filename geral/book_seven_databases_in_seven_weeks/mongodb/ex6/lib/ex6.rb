# frozen_string_literal: true

require 'mongo'

module Ex6
  class << self
    def populate_phones(area: 800, start: 5_550_000, final: 5_650_000)
      @area = area
      @start = start
      @final = final

      db[:phones].bulk_write(phones)

      :cool
    end

    def head
      Array(db[:phones].find.limit(2))
    end

    private

    attr_reader :area, :start, :final

    def phones
      (start..final).collect { |i| phone(i) }
    end

    def phone(index)
      country = 1 + (Integer(rand * 8) << 2)
      num = country * 1e10 + area * 1e7 + index
      prefix = Integer(index * 1e-4) << 0
      full_number = "#{country} #{area} - #{index}"

      components = { country: country, area: area, prefix: prefix, number: index, display: full_number }

      insert_one = { _id: num, components: components }

      { insert_one: insert_one }
    end

    def db
      client.database
    end

    def client
      Mongo::Client.new(['db'], database: 'book', user: 'mongodb', password: 'mongodb', auth_source: 'admin')
    end
  end
end
