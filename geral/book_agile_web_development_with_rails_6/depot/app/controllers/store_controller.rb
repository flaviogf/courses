class StoreController < ApplicationController
  include CurrentCart

  before_action :incr_times
  before_action :set_cart

  def index
    @products = Product.order(:title)
  end

  private

  def incr_times
    session[:times] ||= 0
    session[:times] += 1
    logger.info "The current user entered #{session[:times]} at the store page"
  end
end
