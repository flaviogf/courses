# frozen_string_literal: true

require 'spec_helper'

class Tea
  def flavor
    :earl_grey
  end
end

RSpec.describe Tea do
  let(:tea) { Tea.new }

  it 'tastes like Earl Grey' do
    expect(tea.flavor).to be :earl_grey
  end
end
