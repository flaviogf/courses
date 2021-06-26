# frozen_string_literal: true

# Class responsible for represent a pokemon
class Pokemon < ApplicationRecord
  def full_name
    "#{name} - #{national_id}"
  end
end
