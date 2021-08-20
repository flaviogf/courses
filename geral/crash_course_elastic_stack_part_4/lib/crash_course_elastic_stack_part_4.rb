# frozen_string_literal: true

require 'elasticsearch'
require 'jbuilder'

require_relative 'crash_course_elastic_stack_part_4/create_new_index'
require_relative 'crash_course_elastic_stack_part_4/reindex'
require_relative 'crash_course_elastic_stack_part_4/remove_negative_values'
require_relative 'crash_course_elastic_stack_part_4/remove_values_greater_than_500'
require_relative 'crash_course_elastic_stack_part_4/get_information_about_documents'
require_relative 'crash_course_elastic_stack_part_4/unit_price_sum'
require_relative 'crash_course_elastic_stack_part_4/lowest_unit_price'
require_relative 'crash_course_elastic_stack_part_4/highest_unit_price'
require_relative 'crash_course_elastic_stack_part_4/unit_price_avg'

module CrashCourseElasticStackPart4
  module_function

  def create_new_index
    CreateNewIndex.new(client).execute
  end

  def reindex
    Reindex.new(client).execute
  end

  def remove_negative_values
    RemoveNegativeValues.new(client).execute
  end

  def remove_values_greater_than_500
    RemoveValuesGreaterThan500.new(client).execute
  end

  def get_information_about_documents
    GetInformationAboutDocuments.new(client).execute
  end

  def unit_price_sum
    UnitPriceSum.new(client).execute
  end

  def lowest_unit_price
    LowestUnitPrice.new(client).execute
  end

  def highest_unit_price
    HighestUnitPrice.new(client).execute
  end

  def unit_price_avg
    UnitPriceAvg.new(client).execute
  end

  def client
    @client ||= Elasticsearch::Client.new(host: 'http://elasticsearch:9200')
  end

  private_class_method :client
end
