# frozen_string_literal: true

require 'forwardable'

module Ex9
  class << self
    def report_altitude_change(current_altitude, previous_altitude)
      current_altitude.to_meters - previous_altitude.to_meters
    end
  end

  class Meters
    extend Forwardable

    def_delegators :@value, :to_s, :to_int, :to_i

    def initialize(value)
      @value = value
    end

    def to_meters
      self
    end

    def -(other)
      self.class.new(value - other.value)
    end

    protected

    attr_reader :value
  end

  class Feet
    def initialize(value)
      @value = value
    end

    def to_meters
      Meters.new((value * 0.3048).round)
    end

    protected

    attr_reader :value
  end
end
