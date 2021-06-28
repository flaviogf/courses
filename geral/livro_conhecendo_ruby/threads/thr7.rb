# frozen_string_literal: true

require 'monitor'

class Counter
  include MonitorMixin

  attr_reader :value

  def initialize
    @value = 0
    super
  end

  def increment
    synchronize do
      @value += 1
    end
  end
end

c1 = Counter.new

t1 = Thread.new { 100_000.times { c1.increment } }
t2 = Thread.new { 100_000.times { c1.increment } }

t1.join
t2.join

puts c1.value
