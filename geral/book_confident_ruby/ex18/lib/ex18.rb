# frozen_string_literal: true

require 'faraday'
require 'json'
require 'logger'

module Ex18
  class << self
    def sprites!(options = {})
      @logger = options.fetch(:logger) { Logger.new($stdout) }

      @logger = Logger.new('/dev/null') if @logger == false

      threads = pokemons.collect do |p|
        Thread.new do
          @logger.info("getting info about #{p.fetch('name')}")

          response = client.get(p.fetch('url'))

          body = JSON.parse(response.body)

          sprite = body.dig('sprites', 'front_default')

          @logger.info("downloading sprit of #{p.fetch('name')}")

          response = client.get(sprite)

          filename = File.join(File.expand_path(__dir__), '..', 'sprites', "#{body.fetch('name')}.png")

          File.open(filename, 'wb') { |f| f.write(response.body) }

          @logger.info("sprite of #{p.fetch('name')} downloaded")
        end
      end

      threads.each(&:join)
    end

    def pokemons
      url = 'https://pokeapi.co/api/v2/pokemon'

      @logger.info("getting all pokemons at #{url}")

      response = client.get(url)

      body = JSON.parse(response.body)

      @logger.info('all pokemons were get')

      Array(body.fetch('results'))
    end

    def client
      @client ||= Faraday.new { |f| f.options.timeout = 5 }
    end
  end
end
