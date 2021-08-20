# frozen_string_literal: true

module CrashCourseElasticStackPart4
  class Cardinality
    def initialize(client)
      @client = client
    end

    def execute
      body = Jbuilder.encode do |json|
        json.size 0
        json.aggs do
          json.number_unique_customers do
            json.cardinality do
              json.field 'CustomerID'
            end
          end
        end
      end

      @client.search(index: 'ecommerce_data', body: body)
    end
  end
end
