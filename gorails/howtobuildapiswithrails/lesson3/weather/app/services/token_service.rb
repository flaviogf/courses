# frozen_string_literal: true

require 'jwt'

class TokenService
  class << self
    def encode(payload)
      JWT.encode({ sub: payload[:user_id] }, Rails.application.secret_key_base, 'HS256')
    end

    def decode(token)
      JWT.decode(token, Rails.application.secret_key_base, true, { algorithm: 'HS256' }).first
    rescue JWT::DecodeError
      nil
    end
  end
end
