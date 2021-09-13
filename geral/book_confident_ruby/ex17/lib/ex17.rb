# frozen_string_literal: true

module Ex17
  module_function

  def add_user(attributes)
    login = attributes.fetch(:login)
    password = attributes.fetch(:password)

    command = %w[useradd]

    command << '--home' << attributes[:home] if attributes[:home]

    password == false ? command << '--disabled-login' : command << '--password' << password

    command << login

    command
  end
end
