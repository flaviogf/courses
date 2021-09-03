# frozen_string_literal: true

require_relative 'test_helper'

module Ex14
  class TrafficLightTest < MiniTest::Test
    def setup
      @traffic_light = TrafficLight.new
    end

    def test_change_to
      assert_instance_of(TrafficLight::Stop, @traffic_light.change_to(:stop))
      assert_instance_of(TrafficLight::Stop, @traffic_light.change_to(TrafficLight::Stop.new))
      assert_instance_of(TrafficLight::Caution, @traffic_light.change_to(:caution))
      assert_instance_of(TrafficLight::Caution, @traffic_light.change_to(TrafficLight::Caution.new))
      assert_instance_of(TrafficLight::Proceed, @traffic_light.change_to(:proceed))
      assert_instance_of(TrafficLight::Proceed, @traffic_light.change_to(TrafficLight::Proceed.new))
    end
  end
end
