require 'test_helper'

class ProductTest < ActiveSupport::TestCase
  test 'when title is empty expect to has an error' do
    product = Product.new(title: '')
    product.valid?
    assert product.errors[:title].any?
  end

  test 'when description is empty expect to has an error' do
    product = Product.new(description: '')
    product.valid?
    assert product.errors[:description].any?
  end
end
