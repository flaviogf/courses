class SessionController < ApplicationController
  def create
    user = User.find_by email: session_params[:email]

    return render json: { errors: 'wrong email or password' } if not user or not user.authenticate(session_params[:password])

    payload = { id: user.id }

    @token = JWT.encode payload, Rails.application.secrets.secret_key_base, 'HS256'
  end

  private
  def session_params
    params.permit :email, :password
  end
end
