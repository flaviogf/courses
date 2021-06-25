# frozen_string_literal: true

module Api
  module V1
    class LocationsController < ApiController
      before_action :authenticate_user

      def index
        render json: Location.all
      end
    end
  end
end
