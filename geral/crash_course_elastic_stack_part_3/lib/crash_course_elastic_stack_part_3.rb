# frozen_string_literal: true

require 'elasticsearch'
require 'jbuilder'

module CrashCourseElasticStackPart3
  class << self
    def by_category_aggregation
      query = Jbuilder.encode do |json|
        json.aggs do
          json.by_category do
            json.terms do
              json.field 'category'
              json.size 100
            end
          end
        end
      end

      client.search(index: 'news_headlines', body: query)
    end

    private

    def client
      @client ||= Elasticsearch::Client.new(host: 'http://es01:9200')
    end
  end
end
