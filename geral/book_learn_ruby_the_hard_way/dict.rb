# frozen_string_literal: true

module Dict
  module_function

  def new(num_buckets = 256)
    result = []

    num_buckets.times do |i|
      result.push(i)
    end

    result
  end

  def hash_key(dict, key)
    key.hash % dict.length
  end
end
