# frozen_string_literal: true

RSpec.describe 'An ideal sandwich' do
  Sandwich = Struct.new(:tast, :toppings)

  it 'is delicious' do
    sandwich = Sandwich.new('delicious', [])
    taste = sandwich.tast

    expect(taste).to eq('delicious')
  end

  it 'lets me add toppings' do
    sandwich = Sandwich.new('delicious', [])
    sandwich.toppings << 'cheese'
    toppings = sandwich.toppings

    expect(toppings).not_to be_empty
  end
end
