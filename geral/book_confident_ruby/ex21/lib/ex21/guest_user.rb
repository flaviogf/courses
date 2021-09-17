# frozen_string_literal: true

module Ex21
  class GuestUser
    def name
      'anonymous'
    end

    def authenticated?
      false
    end

    def role?(_role)
      false
    end
  end
end
