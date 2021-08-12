# frozen_string_literal: true

module Dict
  module_function

  def new(num_buckets = 256)
    result = []

    num_buckets.times do
      result.push([])
    end

    result
  end

  def get_bucket(dict, key)
    bucket_id = hash_key(dict, key)
    dict[bucket_id]
  end

  def hash_key(dict, key)
    key.hash % dict.length
  end
end
