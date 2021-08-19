# frozen_string_literal: true

module CrashCourseElasticStackPart4
  class RemoveNegativeValues
    def initialize(client)
      @client = client
    end

    def execute
      body = Jbuilder.encode do |json|
        json.query do
          json.range do
            json.UnitPrice do
              json.lte 0
            end
          end
        end
      end

      @client.delete_by_query(index: 'ecommerce_data', body: body)
    end
  end
end
