# frozen_string_literal: true

Sandwich = Struct.new(:tast, :toppings)

RSpec.describe 'An ideal sandwich' do
  it 'is delicious' do
    sandwich = Sandwich.new('delicious', [])

    taste = sandwich.tast

    expect(taste).to eq('delicious')
  end
end
