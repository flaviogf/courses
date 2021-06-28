# frozen_string_literal: true

require 'rails_helper'

RSpec.describe CreatePokemon do
  describe '#create', vcr: { cassette_name: 'CreatePokemon/create' } do
    let(:create_pokemon) do
      CreatePokemon.new(6)
    end

    it 'creates a new pokemon' do
      expect do
        create_pokemon.create
      end.to change { Pokemon.count }.by 1
    end

    context 'when pokemon was created' do
      subject do
        Pokemon.last
      end

      before do
        create_pokemon.create
      end

      it { expect(subject.name).to eq('Charizard') }
    end
  end
end
