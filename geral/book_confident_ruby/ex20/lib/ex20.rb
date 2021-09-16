# frozen_string_literal: true

require 'logger'

module Ex20
  module_function

  def log_reading(reading_or_readings, **options)
    quiet = options.fetch(:quiet) { false }

    return if quiet

    readings = Array(reading_or_readings)
    readings.each do |reading|
      logger.info(format('[READING] %<reading>3.2f', reading: reading))
    end
  end

  def logger
    @logger ||= Logger.new($stdout)
  end
end
