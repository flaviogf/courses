# frozen_string_literal: true

require 'ex21/guest_user'
require 'ex21/user'

module Ex21
  module_function

  def greeting(current_user)
    "Hello #{current_user.name}, how are you doing?"
  end

  def button(current_user)
    if current_user.authenticated?
      'logout'
    else
      'login'
    end
  end

  def admin?(current_user)
    if current_user.role?(:admin)
      'Yeah'
    else
      'Noops'
    end
  end
end
