# frozen_string_literal: true

require 'yaml'

def seconds_in_day
  24 * 60 * 60
end

puts seconds_in_day

SECONDS_IN_DAY = 24 * 60 * 60

puts SECONDS_IN_DAY

def seconds_in_days(num_days)
  num_days * 24 * 60 * 60
end

puts seconds_in_days(2)

class TimeCalc
  SECONDS_IN_DAY = 24 * 60 * 60

  def seconds_in_week
    seconds_in_days(7)
  end

  def seconds_in_days(num_days)
    num_days * SECONDS_IN_DAY
  end
end

puts TimeCalc.new.seconds_in_days(2)

puts TimeCalc.new.seconds_in_week

class TimeCalc
  def initialize
    @start_date = Time.now
  end

  def time_n_days_from_now(num_days)
    @start_date + num_days * 24 * 60 * 60
  end
end

puts TimeCalc.new.time_n_days_from_now(2)

def format_time
  format = ENV.fetch('TIME_FORMAT', '%D %r')
  Time.now.strftime(format)
end

puts format_time

def format_time
  prefs = YAML.load_file('time-prefs.yml')
  format = prefs.fetch('format')
  Time.now.strftime(format)
end

puts format_time
