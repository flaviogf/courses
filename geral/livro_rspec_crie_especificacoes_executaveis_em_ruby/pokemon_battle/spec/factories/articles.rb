# frozen_string_literal: true

FactoryGirl.define do
  factory :article do
    title 'Article 1'

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
