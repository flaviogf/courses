# frozen_string_literal: true

module CrashCourseElasticStackPart4
  class UnitPriceAvgInGermany
    def initialize(client)
      @client = client
    end

    def execute
      body = Jbuilder.encode do |json|
        json.size 0
        json.query do
          json.match do
            json.Country 'Germany'
          end
        end
        json.aggs do
          json.unit_price_avg_in_germany do
            json.avg do
              json.field 'UnitPrice'
            end
          end
        end
      end

      @client.search(index: 'ecommerce_data', body: body)
    end
  end
end
