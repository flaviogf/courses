# frozen_string_literal: true

class ApiController < ApplicationController
  skip_before_action :verify_authenticity_token

  protected

  def authenticate_user
    head :unauthorized unless current_user.present?
  end

  def current_user
    authorization = request.headers.fetch 'Authorization', ''

    return nil unless authorization.present?

    token = authorization[7..]

    claims = TokenService.decode token

    return nil unless claims.present?

    @current_user ||= User.find_by id: claims['sub']
  end
end
