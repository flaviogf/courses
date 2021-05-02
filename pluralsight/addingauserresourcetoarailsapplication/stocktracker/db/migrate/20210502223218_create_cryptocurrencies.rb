class CreateCryptocurrencies < ActiveRecord::Migration[6.1]
  def change
    create_table :cryptocurrencies do |t|
      t.string :name
      t.string :ticker_symbol

      t.timestamps
    end
  end
end
