require 'test_helper'

class Api::V1::LocationsControllerTest < ActionDispatch::IntegrationTest
  test 'index should get index' do
    get api_v1_locations_path

    assert_response :success
  end

  test 'index should return locations' do
    get api_v1_locations_path

    locations = response.parsed_body

    assert_equal 1, locations.size
  end

  test 'index should return current temp' do
    get api_v1_locations_path

    locations = response.parsed_body

    assert_equal 32, locations[0]['current']['temp']
  end

  test 'index should return current status' do
    get api_v1_locations_path

    locations = response.parsed_body

    assert_equal 'cloudy', locations[0]['current']['status']
  end
end
