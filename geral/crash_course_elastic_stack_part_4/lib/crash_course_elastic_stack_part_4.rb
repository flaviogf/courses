# frozen_string_literal: true

require 'elasticsearch'
require 'jbuilder'

require_relative 'crash_course_elastic_stack_part_4/create_new_index'
require_relative 'crash_course_elastic_stack_part_4/reindex'

module CrashCourseElasticStackPart4
  module_function

  def create_new_index
    CreateNewIndex.new(client).execute
  end

  def reindex
    Reindex.new(client).execute
  end

  def remove_negative_values
    'removing negative values'
  end

  def client
    @client ||= Elasticsearch::Client.new(host: 'http://elasticsearch:9200')
  end

  private_class_method :client
end
