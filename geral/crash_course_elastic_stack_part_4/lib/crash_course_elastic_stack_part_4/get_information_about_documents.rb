# frozen_string_literal: true

module CrashCourseElasticStackPart4
  class GetInformationAboutDocuments
    def initialize(client)
      @client = client
    end

    def execute
      @client.search(index: 'ecommerce_data')
    end
  end
end
