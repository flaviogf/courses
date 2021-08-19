# frozen_string_literal: true

module CrashCourseElasticStackPart4
  class Reindex
    def initialize(client)
      @client = client
    end

    def execute
      body = Jbuilder.encode do |json|
        json.source do
          json.index 'ecommerce'
        end
        json.dest do
          json.index 'ecommerce_data'
        end
      end

      @client.reindex(body: body)
    end
  end
end
