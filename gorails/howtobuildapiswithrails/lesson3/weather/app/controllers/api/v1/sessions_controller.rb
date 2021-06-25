# frozen_string_literal: true

module Api
  module V1
    class SessionsController < ApiController
      def create
        user = User.find_by email: session_params[:email]

        return head :unauthorized unless user.present?

        return head :unauthorized unless user.authenticate session_params[:password]

        payload = { user_id: user.id }

        token = TokenService.encode payload

        render json: { token: token }
      end

      private

      def session_params
        params.require(:session).permit(:email, :password)
      end
    end
  end
end
