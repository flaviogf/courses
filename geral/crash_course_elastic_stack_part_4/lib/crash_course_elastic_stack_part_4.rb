# frozen_string_literal: true

require 'elasticsearch'
require 'jbuilder'

require_relative 'crash_course_elastic_stack_part_4/create_new_index'

module CrashCourseElasticStackPart4
  module_function

  def create_new_index
    CreateNewIndex.new(Elasticsearch::Client.new(host: 'http://elasticsearch:9200')).execute
  end
end
