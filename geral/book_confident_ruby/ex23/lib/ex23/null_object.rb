# frozen_string_literal: true

module Ex23
  class NullObject
    def method_missing(*)
      self
    end
  end
end
