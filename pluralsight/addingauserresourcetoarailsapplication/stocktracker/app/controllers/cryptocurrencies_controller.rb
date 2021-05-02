class CryptocurrenciesController < ApplicationController
  before_action :set_cryptocurrency, only: %i[ show edit update destroy ]

  # GET /cryptocurrencies or /cryptocurrencies.json
  def index
    @cryptocurrencies = Cryptocurrency.all
  end

  # GET /cryptocurrencies/1 or /cryptocurrencies/1.json
  def show
  end

  # GET /cryptocurrencies/new
  def new
    @cryptocurrency = Cryptocurrency.new
  end

  # GET /cryptocurrencies/1/edit
  def edit
  end

  # POST /cryptocurrencies or /cryptocurrencies.json
  def create
    @cryptocurrency = Cryptocurrency.new(cryptocurrency_params)

    respond_to do |format|
      if @cryptocurrency.save
        format.html { redirect_to @cryptocurrency, notice: "Cryptocurrency was successfully created." }
        format.json { render :show, status: :created, location: @cryptocurrency }
      else
        format.html { render :new, status: :unprocessable_entity }
        format.json { render json: @cryptocurrency.errors, status: :unprocessable_entity }
      end
    end
  end

  # PATCH/PUT /cryptocurrencies/1 or /cryptocurrencies/1.json
  def update
    respond_to do |format|
      if @cryptocurrency.update(cryptocurrency_params)
        format.html { redirect_to @cryptocurrency, notice: "Cryptocurrency was successfully updated." }
        format.json { render :show, status: :ok, location: @cryptocurrency }
      else
        format.html { render :edit, status: :unprocessable_entity }
        format.json { render json: @cryptocurrency.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /cryptocurrencies/1 or /cryptocurrencies/1.json
  def destroy
    @cryptocurrency.destroy
    respond_to do |format|
      format.html { redirect_to cryptocurrencies_url, notice: "Cryptocurrency was successfully destroyed." }
      format.json { head :no_content }
    end
  end

  private
    # Use callbacks to share common setup or constraints between actions.
    def set_cryptocurrency
      @cryptocurrency = Cryptocurrency.find(params[:id])
    end

    # Only allow a list of trusted parameters through.
    def cryptocurrency_params
      params.require(:cryptocurrency).permit(:name, :ticker_symbol)
    end
end
