# frozen_string_literal: true

class Recording < ApplicationRecord
  belongs_to :location

  validates :temp,
            presence: true,
            numericality: { greater_than_or_equal_to: 0, less_than_or_equal_to: 100 }

  validates :status, presence: true
end
