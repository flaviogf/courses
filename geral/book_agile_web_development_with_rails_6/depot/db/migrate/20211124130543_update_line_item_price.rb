class UpdateLineItemPrice < ActiveRecord::Migration[6.0]
  def up
    LineItem.find_each do |item|
      item.price = item.product.price
      item.save!
    end
  end

  def down
    LineItem.find_each do |item|
      item.price = nil
    end
  end
end
