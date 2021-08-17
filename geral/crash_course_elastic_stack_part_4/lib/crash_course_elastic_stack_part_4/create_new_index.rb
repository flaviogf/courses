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
          end
        end
      end

      puts body
    end
  end
end
