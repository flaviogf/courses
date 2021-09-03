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

    def test_turn_on_lamp
      assert_equal('Turning on red lamp', @traffic_light.turn_on_lamp('red'))
    end

    def test_ring_warning_bell
      assert_equal('Ring ring ring', @traffic_light.ring_warning_bell)
    end
  end
end
