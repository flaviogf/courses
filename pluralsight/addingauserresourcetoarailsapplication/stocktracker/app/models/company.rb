class Company < ApplicationRecord
  RISK_FACTORS = [
    "LOW",
    "MEDIUM",
    "HIGH"
  ]

  validates :name, presence: true
  validates :ticker_symbol, presence: true
  validates :risk_factor, presence: true, inclusion: { in: RISK_FACTORS }

  has_many :stock_prices
end
