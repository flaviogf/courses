require "application_system_test_case"

class CryptocurrencyPricesTest < ApplicationSystemTestCase
  setup do
    @cryptocurrency_price = cryptocurrency_prices(:one)
  end

  test "visiting the index" do
    visit cryptocurrency_prices_url
    assert_selector "h1", text: "Cryptocurrency Prices"
  end

  test "creating a Cryptocurrency price" do
    visit cryptocurrency_prices_url
    click_on "New Cryptocurrency Price"

    fill_in "Captured at", with: @cryptocurrency_price.captured_at
    fill_in "Cryptocurrency", with: @cryptocurrency_price.cryptocurrency_id
    fill_in "Price", with: @cryptocurrency_price.price
    click_on "Create Cryptocurrency price"

    assert_text "Cryptocurrency price was successfully created"
    click_on "Back"
  end

  test "updating a Cryptocurrency price" do
    visit cryptocurrency_prices_url
    click_on "Edit", match: :first

    fill_in "Captured at", with: @cryptocurrency_price.captured_at
    fill_in "Cryptocurrency", with: @cryptocurrency_price.cryptocurrency_id
    fill_in "Price", with: @cryptocurrency_price.price
    click_on "Update Cryptocurrency price"

    assert_text "Cryptocurrency price was successfully updated"
    click_on "Back"
  end

  test "destroying a Cryptocurrency price" do
    visit cryptocurrency_prices_url
    page.accept_confirm do
      click_on "Destroy", match: :first
    end

    assert_text "Cryptocurrency price was successfully destroyed"
  end
end
