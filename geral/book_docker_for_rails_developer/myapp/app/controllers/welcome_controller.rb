class WelcomeController < ApplicationController
  def index
    redis.incr :page_hits

    @page_hits = redis.get :page_hits
  end

  private

  def redis
    @redis ||= Redis.new(host: 'redis', port: 6379)
  end
end
