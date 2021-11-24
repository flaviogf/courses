require 'test_helper'

class CartTest < ActiveSupport::TestCase
  fixtures :products

  test 'add_product' do
    cart = Cart.new

    2.times do
      cart.add_product(products(:ruby))
      cart.save!
    end

    cart.add_product(products(:one))
    cart.save!

    assert_equal cart.line_items.count, 2
  end
end
