# frozen_string_literal: true

require 'ex23/null_object'

module Ex23
  module_function

  def execute
    NullObject.new
  end

  def Actual(object)
    case object
    when NullObject then nil
    else object
    end
  end
end
