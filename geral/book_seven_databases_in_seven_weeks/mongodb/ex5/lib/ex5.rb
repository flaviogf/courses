# frozen_string_literal: true

require 'json'
require 'mongoid'

Mongoid.load!(File.join(File.expand_path(__dir__), '..', 'config', 'mongoid.yml'))

module Ex5
  class << self
    def import_countries
      Country.collection.insert_many(countries)
      puts 'oh yeah, your import has finished'
    rescue StandardError
      puts 'oops, you already have done the import'
    end

    def remove_country
      Country.find('us').destroy
      puts 'ok, we removed this country'
    rescue StandardError
      puts 'oops, we could not find this country'
    end

    private

    def countries
      IO.readlines(filename, chomp: true).drop(1).collect(&method(:country_from))
    end

    def filename
      File.join(File.expand_path(__dir__), '..', 'countries.csv')
    end

    def country_from(row)
      id, name, foods = row.split(';')

      {
        _id: String(id),
        name: String(name),
        exports: {
          foods: Array(JSON.parse(foods)).collect(&:symbolize_keys)
        }
      }
    end
  end

  class Country
    include Mongoid::Document

    field :name, type: String

    embeds_one :exports
  end

  class Export
    include Mongoid::Document

    embeds_many :foods
  end

  class Food
    include Mongoid::Document

    field :name, type: String
    field :tasty, type: Boolean
  end
end
