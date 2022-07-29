# frozen_string_literal: true

require 'spec_helper'

class Coffee
  def initialize
    @ingredients = []
  end

  def price
    1.0 + @ingredients.size * 0.25
  end

  def add(ingredient)
    @ingredients << ingredient
  end
end

RSpec.describe 'A cup of coffee' do
  let(:coffee) { Coffee.new }

  fit 'costs $1' do
    expect(coffee.price).to eq(1.0)
  end

  context 'with milk' do
    before { coffee.add :milk }

    it 'costs $1.25' do
      expect(coffee.price).to eq(1.25)
    end
  end
end
