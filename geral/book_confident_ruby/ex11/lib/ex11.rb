# frozen_string_literal: true

module Ex11
  module_function

  def log_reading(reading_or_readings)
    readings = Array(reading_or_readings)
    readings.map do |reading|
      '[READING] %3.2f' % reading
    end
  end
end
