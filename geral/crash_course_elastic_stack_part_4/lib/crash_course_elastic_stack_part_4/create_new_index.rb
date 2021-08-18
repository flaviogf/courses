# frozen_string_literal: true

module CrashCourseElasticStackPart4
  class CreateNewIndex
    def initialize(client)
      @client = client
    end

    def execute
      body = Jbuilder.encode do |json|
        json.mappings do
          json.properties do
            json.Country do
              json.type 'keyword'
            end
            json.CountryID do
              json.type 'long'
            end
            json.Description do
              json.type 'text'
            end
            json.InvoiceDate do
              json.type 'date'
              json.format 'M/d/yyyy H:m'
            end
            json.InvoiceNo do
              json.type 'keyword'
            end
            json.Quantity do
              json.type 'long'
            end
            json.StockCode do
              json.type 'keyword'
            end
            json.UnitPrice do
              json.type 'double'
            end
          end
        end
      end

      @client.indices.create(index: 'ecommerce_data', body: body)
    end
  end
end
