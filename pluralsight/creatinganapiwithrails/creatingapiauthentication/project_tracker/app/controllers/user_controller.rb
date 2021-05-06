class UserController < ApplicationController
  def create
    user = User.create user_params

    if user.valid?
      render json: user
    else
      render json: user.errors.messages
    end
  end

  private
  def user_params
    params.permit :email, :password, :password_confirmation
  end
end
