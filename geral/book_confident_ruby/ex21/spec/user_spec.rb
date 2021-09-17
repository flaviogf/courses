# frozen_string_literal: true

module Ex21
  RSpec.describe User do
    subject { User.new(Faker::Name.name) }

    it_behaves_like 'a user'
  end
end
