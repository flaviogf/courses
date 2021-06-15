class ApplicationController < ActionController::Base
  delegate :current_user, :user_signed_in?, to: :user_session

  before_action do
    I18n.locale = params[:locale] || I18n.default_locale
  end

  def default_url_options
    { locale: I18n.locale }
  end

  def user_session
    UserSession.new(session)
  end

  def require_authentication
    redirect_to new_user_sessions_path, alert: t('flash.alert.needs_login') unless user_signed_in?
  end

  def require_no_authentication
    redirect_to root_path, notice: t('flash.notice.already_logged_in') if user_signed_in?
  end

  helper_method :current_user, :user_signed_in?
end
