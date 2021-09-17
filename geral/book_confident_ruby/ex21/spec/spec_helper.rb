# frozen_string_literal: true

require 'faker'
require 'ex21'

RSpec.configure do |config|
  config.expect_with :rspec do |expectations|
    expectations.include_chain_clauses_in_custom_matcher_descriptions = true
  end

  config.mock_with :rspec do |mocks|
    mocks.verify_partial_doubles = true
  end

  config.shared_context_metadata_behavior = :apply_to_host_groups
end

RSpec.shared_examples 'a user' do
  it { is_expected.to respond_to(:name) }

  it { is_expected.to respond_to(:authenticated?) }

  it { is_expected.to respond_to(:role?) }
end
