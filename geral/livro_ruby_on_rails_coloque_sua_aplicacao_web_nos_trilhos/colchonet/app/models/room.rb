class Room < ApplicationRecord
  scope :most_recent, -> { order(created_at: :desc) }

  belongs_to :user

  validates_presence_of :title, :location

  validates_length_of :description, minimum: 30, allow_blank: true
end
