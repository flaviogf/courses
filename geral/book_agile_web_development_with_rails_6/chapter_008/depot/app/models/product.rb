class Product < ApplicationRecord
  validates :title, :description, :image_url, :price, presence: true
  validates :price, numericality: { greater_than_or_equal_to: 0.01 }
  validates :title, uniqueness: true
  validates :image_url, format: { with: /.*\.(png|jpg)\z/ }
end
