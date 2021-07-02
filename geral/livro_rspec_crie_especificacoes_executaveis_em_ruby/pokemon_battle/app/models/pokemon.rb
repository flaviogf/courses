# frozen_string_literal: true

class Pokemon < ApplicationRecord
  validates :name, presence: true

  scope :chose_yesterday, -> { where(chose_at: 1.day.ago.midnight..Time.zone.now.midnight) }

  def full_name
    "#{name} - #{national_id}" if name && national_id
  end

  def critical_attack
    Random.rand(60..80)
  end
end
