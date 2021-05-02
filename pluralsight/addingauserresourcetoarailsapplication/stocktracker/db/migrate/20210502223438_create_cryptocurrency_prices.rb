class CreateCryptocurrencyPrices < ActiveRecord::Migration[6.1]
  def change
    create_table :cryptocurrency_prices do |t|
      t.decimal :price
      t.datetime :captured_at
      t.references :cryptocurrency, null: false, foreign_key: true

      t.timestamps
    end
  end
end
