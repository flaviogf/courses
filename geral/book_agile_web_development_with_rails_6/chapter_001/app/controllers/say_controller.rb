class SayController < ApplicationController
  def hello
    @time = Time.zone.now
  end

  def goodbye
  end
end
