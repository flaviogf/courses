class Api::V1::LocationsController < ApiController
  def index
    @locations = Location.all
  end
end
