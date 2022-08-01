# frozen_string_literal: true

require 'spec_helper'

class Coffee
  attr_reader :ingredients

  def initialize
    @ingredients = []
  end

  def add(ingredient)
    ingredients << ingredient
  end

  def price
    1.0 + 0.25 * ingredients.size
  end

  def color
    ingredients.include?(:milk) ? :light : :dark
  end

  def temperature
    ingredients.include?(:milk) ? 190.0 : 250.0
  end
end

RSpec.describe 'An cupp of coffee', :no_database do
  let(:coffee) { Coffee.new }

  it 'costs $1' do
    expect(coffee.price).to eq(1.0)
  end

  context 'with milk' do
    before { coffee.add :milk }

    it 'costs $1.25' do
      expect(coffee.price).to eq(1.25)
    end

    it 'is cooler than 200 degree Fahrenheit' do
      expect(coffee.temperature).to be < 200.00
    end

    it 'is light in color' do
      expect(coffee.color).to be(:light)
    end
  end
end
