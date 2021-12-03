class SessionsController < ApplicationController
  def new
  end

  def create
    user = User.find_by(name: params[:name])

    return redirect_to login_url, alert: 'Invalid user/password combination' unless user.try(:authenticate, params[:password])

    session[:user_id] = user.id
    redirect_to admin_url
  end

  def destroy
    session[:user_id] = nil
    redirect_to store_index_url, notice: 'Logged out'
  end
end
