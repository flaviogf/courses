class Room < ApplicationRecord
  validates_presence_of :title, :location

  validates_length_of :description, minimum: 30, allow_blank: true
end
