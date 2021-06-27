# frozen_string_literal: true

class Pokemon < ApplicationRecord
  def full_name
    "#{name} - #{national_id}" if name && national_id
  end
end
