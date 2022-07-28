# frozen_string_literal: true

require 'spec_helper'

class Coffee
  def price
    1.0
  end

  def add(ingredient); end
end

RSpec.describe 'A cup of coffee' do
  let(:coffee) { Coffee.new }

  it 'costs $1' do
    expect(coffee.price).to eq(1.00)
  end

  context 'with milk' do
    before { coffee.add :milk }

    it 'costs $1.25' do
      pending 'Not yet implemented'

      expect(coffee.price).to eq(1.25)
    end
  end
end
