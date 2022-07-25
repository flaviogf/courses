# frozen_string_literal: true

RSpec.describe 'An ideal sandwich' do
  Sandwich = Struct.new(:tast, :toppings)

  it 'is delicious' do
    sandwich = Sandwich.new('delicious', [])
    taste = sandwich.tast
    expect(taste).to eq('delicious')
  end
end
