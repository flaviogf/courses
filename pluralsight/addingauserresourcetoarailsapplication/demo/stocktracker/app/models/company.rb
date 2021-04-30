class Company < ApplicationRecord
  validates :name, presence: true, uniqueness: true

  validates :ticker_symbol, presence: true, uniqueness: true

  has_many :stock_prices
end
