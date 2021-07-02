# frozen_string_literal: true

class CardPresenter
  def initialize(object)
    @object = object
  end

  def show
    object.to_presenter.to_a.map { |key, value| "<p>#{key}: #{value}</p>" }.join
  end

  private

  attr_reader :object
end
