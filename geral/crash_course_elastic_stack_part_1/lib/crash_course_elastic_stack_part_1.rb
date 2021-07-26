# frozen_string_literal: true

require 'elasticsearch'

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

    private

    def client
      @client ||= Elasticsearch::Client.new(host: 'elasticsearch:9200', log: true)
    end
  end
end
