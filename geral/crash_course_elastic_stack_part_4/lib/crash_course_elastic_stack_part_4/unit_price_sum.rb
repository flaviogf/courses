# frozen_string_literal: true

module CrashCourseElasticStackPart4
  class UnitPriceSum
    def initialize(client)
      @client = client
    end

    def execute
      body = Jbuilder.encode do |json|
        json.size 0
        json.aggs do
          json.unit_price_sum do
            json.sum do
              json.field 'UnitPrice'
            end
          end
        end
      end

      @client.search(index: 'ecommerce_data', body: body)
    end
  end
end
