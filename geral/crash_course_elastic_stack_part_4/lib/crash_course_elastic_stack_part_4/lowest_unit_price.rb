# frozen_string_literal: true

module CrashCourseElasticStackPart4
  class LowestUnitPrice
    def initialize(client)
      @client = client
    end

    def execute
      body = Jbuilder.encode do |json|
        json.size 0
        json.aggs do
          json.lowest_unit_price do
            json.min do
              json.field 'UnitPrice'
            end
          end
        end
      end

      @client.search(index: 'ecommerce_data', body: body)
    end
  end
end
