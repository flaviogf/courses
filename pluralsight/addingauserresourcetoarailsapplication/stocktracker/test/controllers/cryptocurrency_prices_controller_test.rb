require "test_helper"

class CryptocurrencyPricesControllerTest < ActionDispatch::IntegrationTest
  setup do
    @cryptocurrency_price = cryptocurrency_prices(:one)
  end

  test "should get index" do
    get cryptocurrency_prices_url
    assert_response :success
  end

  test "should get new" do
    get new_cryptocurrency_price_url
    assert_response :success
  end

  test "should create cryptocurrency_price" do
    assert_difference('CryptocurrencyPrice.count') do
      post cryptocurrency_prices_url, params: { cryptocurrency_price: { captured_at: @cryptocurrency_price.captured_at, cryptocurrency_id: @cryptocurrency_price.cryptocurrency_id, price: @cryptocurrency_price.price } }
    end

    assert_redirected_to cryptocurrency_price_url(CryptocurrencyPrice.last)
  end

  test "should show cryptocurrency_price" do
    get cryptocurrency_price_url(@cryptocurrency_price)
    assert_response :success
  end

  test "should get edit" do
    get edit_cryptocurrency_price_url(@cryptocurrency_price)
    assert_response :success
  end

  test "should update cryptocurrency_price" do
    patch cryptocurrency_price_url(@cryptocurrency_price), params: { cryptocurrency_price: { captured_at: @cryptocurrency_price.captured_at, cryptocurrency_id: @cryptocurrency_price.cryptocurrency_id, price: @cryptocurrency_price.price } }
    assert_redirected_to cryptocurrency_price_url(@cryptocurrency_price)
  end

  test "should destroy cryptocurrency_price" do
    assert_difference('CryptocurrencyPrice.count', -1) do
      delete cryptocurrency_price_url(@cryptocurrency_price)
    end

    assert_redirected_to cryptocurrency_prices_url
  end
end
