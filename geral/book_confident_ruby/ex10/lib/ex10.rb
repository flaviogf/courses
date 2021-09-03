# frozen_string_literal: true

module Ex10
  module_function

  def pretty_int(value)
    decimal = Integer(value).to_s
    leader = decimal.slice!(0, decimal.length % 3)
    decimal.gsub!(/\d{3}(?!$)/, '\0,')
    decimal = nil if decimal.empty?
    leader = nil if leader.empty?
    [leader, decimal].compact.join(',')
  end
end
