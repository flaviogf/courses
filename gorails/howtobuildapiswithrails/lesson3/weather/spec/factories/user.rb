# frozen_string_literal: true

FactoryBot.define do
  factory :user do
    email { 'frank@email.com' }
    password { 'test' }
  end
end
