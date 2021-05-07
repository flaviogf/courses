class ApplicationController < ActionController::API
  def current_user
    authorization = request.headers[:authorization]

    return nil if not authorization

    token = authorization[7..]

    return nil if not token

    claims, _ = JWT.decode token, Rails.application.secrets.secret_key_base, true, { algorithm: 'HS256' }

    User.find claims['id']
  end

  private
  def authorize
    head(401) if not current_user
  end
end
