class UserSessionsController < ApplicationController
  before_action :require_no_authentication, only: [:new, :create]
  before_action :require_authentication, only: :destroy

  def new
    @user_session = UserSession.new(session)
  end

  def create
    @user_session = UserSession.new(session, user_session_params)

    if @user_session.authenticate!
      redirect_to root_path, notice: I18n.t('flash.notice.signed_in')
    else
      render :new
    end
  end

  def destroy
    user_session.destroy

    redirect_to root_path, notice: t('flash.notice.signed_out')
  end

  private
  def user_session_params
    params.require(:user_session).permit(:email, :password)
  end
end
