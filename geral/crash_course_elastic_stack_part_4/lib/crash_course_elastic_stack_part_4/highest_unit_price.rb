# frozen_string_literal: true

module CrashCourseElasticStackPart4
  class HighestUnitPrice
    def initialize(client)
      @client = client
    end

    def execute
      body = Jbuilder.encode do |json|
        json.size 0
        json.aggs do
          json.highest_unit_price do
            json.max do
              json.field 'UnitPrice'
            end
          end
        end
      end

      @client.search(index: 'ecommerce_data', body: body)
    end
  end
end
