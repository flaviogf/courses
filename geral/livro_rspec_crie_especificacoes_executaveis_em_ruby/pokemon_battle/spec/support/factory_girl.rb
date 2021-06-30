# frozen_string_literal: true

RSpec.configure do |c|
  c.include FactoryGirl::Syntax::Methods

  c.before :suite do
    FactoryGirl.lint
  end
end
