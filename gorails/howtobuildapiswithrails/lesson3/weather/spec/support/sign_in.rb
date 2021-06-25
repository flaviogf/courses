# frozen_string_literal: true

module SignInHelper
  def sign_in(user)
    request.headers.merge!({ 'Authorization' => "Bearer #{TokenService.encode({ user_id: user.id })}" })
  end
end

RSpec.configure do |config|
  config.include SignInHelper
end
