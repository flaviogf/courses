# frozen_string_literal: true

FactoryBot.define do
  factory :recording do
    location
    temp { 1 }
    status { 'Cloudy' }
  end
end
