class StoreController < ApplicationController
  include Counter
  include CurrentCart

  skip_before_action :authorize
  before_action :increment
  before_action :set_cart

  def index
    @products = Product.order(:title)
  end
end
