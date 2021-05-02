class CryptocurrencyPricesController < ApplicationController
  before_action :set_cryptocurrency_price, only: %i[ show edit update destroy ]

  # GET /cryptocurrency_prices or /cryptocurrency_prices.json
  def index
    @cryptocurrency_prices = CryptocurrencyPrice.all
  end

  # GET /cryptocurrency_prices/1 or /cryptocurrency_prices/1.json
  def show
  end

  # GET /cryptocurrency_prices/new
  def new
    @cryptocurrency_price = CryptocurrencyPrice.new
  end

  # GET /cryptocurrency_prices/1/edit
  def edit
  end

  # POST /cryptocurrency_prices or /cryptocurrency_prices.json
  def create
    @cryptocurrency_price = CryptocurrencyPrice.new(cryptocurrency_price_params)

    respond_to do |format|
      if @cryptocurrency_price.save
        format.html { redirect_to @cryptocurrency_price, notice: "Cryptocurrency price was successfully created." }
        format.json { render :show, status: :created, location: @cryptocurrency_price }
      else
        format.html { render :new, status: :unprocessable_entity }
        format.json { render json: @cryptocurrency_price.errors, status: :unprocessable_entity }
      end
    end
  end

  # PATCH/PUT /cryptocurrency_prices/1 or /cryptocurrency_prices/1.json
  def update
    respond_to do |format|
      if @cryptocurrency_price.update(cryptocurrency_price_params)
        format.html { redirect_to @cryptocurrency_price, notice: "Cryptocurrency price was successfully updated." }
        format.json { render :show, status: :ok, location: @cryptocurrency_price }
      else
        format.html { render :edit, status: :unprocessable_entity }
        format.json { render json: @cryptocurrency_price.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /cryptocurrency_prices/1 or /cryptocurrency_prices/1.json
  def destroy
    @cryptocurrency_price.destroy
    respond_to do |format|
      format.html { redirect_to cryptocurrency_prices_url, notice: "Cryptocurrency price was successfully destroyed." }
      format.json { head :no_content }
    end
  end

  private
    # Use callbacks to share common setup or constraints between actions.
    def set_cryptocurrency_price
      @cryptocurrency_price = CryptocurrencyPrice.find(params[:id])
    end

    # Only allow a list of trusted parameters through.
    def cryptocurrency_price_params
      params.require(:cryptocurrency_price).permit(:price, :captured_at, :cryptocurrency_id)
    end
end
