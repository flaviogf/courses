class CreateStockPrices < ActiveRecord::Migration[6.1]
  def change
    create_table :stock_prices do |t|
      t.decimal :price
      t.datetime :captured_at
      t.references :company, null: false, foreign_key: true

      t.timestamps
    end
  end
end
