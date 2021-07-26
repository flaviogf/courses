# frozen_string_literal: true

require 'elasticsearch'
require 'jbuilder'

module CrashCourseElasticStackPart1
  class << self
    def health
      client.cluster.health
    end

    def stats
      client.nodes.stats
    end

    def create_favorite_candy_index
      client.indices.create(index: 'favorite_candy')
    end

    def index_document
      query = Jbuilder.encode do |json|
        json.first_name 'Lisa'
        json.candy 'Sour Skittles'
      end

      client.index(index: 'favorite_candy', body: query)

      query = Jbuilder.encode do |json|
        json.first_name 'John'
        json.candy 'Starburst'
      end

      client.index(index: 'favorite_candy', body: query, id: 1)
    end

    def read_document
      client.get(index: 'favorite_candy', id: 1)
    end

    def update_document
      query = Jbuilder.encode do |json|
        json.doc do
          json.candy "M&M's"
        end
      end

      client.update(index: 'favorite_candy', id: 1, body: query)
    end

    private

    def client
      @client ||= Elasticsearch::Client.new(host: 'elasticsearch:9200', log: true)
    end
  end
end
