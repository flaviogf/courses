# frozen_string_literal: true

RSpec::Matchers.define :check_presence_of do |attr|
  match do |subject|
    params = {}
    instance = subject.class.new(params)
    instance.valid?
    !instance.errors[attr].empty?
  end

  failure_message do
    "#{subject.class} is not checking presence of #{attr}"
  end
end
