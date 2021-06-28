# frozen_string_literal: true

class CreatePokemon
  def initialize(national_id)
    @national_id = national_id
  end

  def create
    Pokemon.create name: name, national_id: national_id
  end

  private

  attr_reader :national_id

  def name
    response = Net::HTTP.get(endpoint)

    data = JSON.parse(response)

    data['name'].to_s.capitalize
  end

  def endpoint
    URI("https://pokeapi.co/api/v2/pokemon/#{national_id}")
  end
end
