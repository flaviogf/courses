# frozen_string_literal: true

FactoryGirl.define do
  sequence :title do |n|
    "Some tips of RSpec #{n}"
  end

  factory :article do
    title
    content { "Content of the article #{title}. Approved: #{approved}" }
    created_at { 2.days.ago }

    factory :approved_article do
      approved true
    end

    factory :disapproved_article do
      approved false
    end

    trait :approved do
      approved true
    end

    trait :disapproved do
      approved false
    end
  end
end
