# frozen_string_literal: true

class Location < ApplicationRecord
  has_many :recordings

  validates :name, presence: true
end
