# frozen_string_literal: true

APP_PATH = File.join(File.expand_path(__dir__), '..', 'app')

$LOAD_PATH.unshift(APP_PATH) unless $LOAD_PATH.include?(APP_PATH)

require 'api'
require 'rack/test'

RSpec.configure do |config|
  config.expect_with :rspec do |expectations|
    expectations.include_chain_clauses_in_custom_matcher_descriptions = true
  end

  config.mock_with :rspec do |mocks|
    mocks.verify_partial_doubles = true
  end

  config.shared_context_metadata_behavior = :apply_to_host_groups

  config.filter_run_when_matching :focus

  config.disable_monkey_patching!

  config.order = :random

  Kernel.srand config.seed
end
