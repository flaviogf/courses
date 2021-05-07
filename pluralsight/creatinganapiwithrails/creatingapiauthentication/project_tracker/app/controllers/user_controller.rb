class UserController < ApplicationController
  def create
    @user = User.create user_params

    render json: { errors: @user.errors} if not @user.valid?
  end

  private
  def user_params
    params.permit :email, :password, :password_confirmation
  end
end
