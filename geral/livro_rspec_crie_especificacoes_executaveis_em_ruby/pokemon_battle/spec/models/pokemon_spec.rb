# frozen_string_literal: true

require 'rails_helper'

RSpec.describe Pokemon, type: :model do
  describe '#full_name' do
    context 'when has name and national id' do
      subject { Pokemon.new(name: 'Charizard', national_id: 6).full_name }

      it { is_expected.to eq('Charizard - 6') }
    end

    context 'when has not name and has not national id' do
      subject { Pokemon.new.full_name }

      it { is_expected.to be_nil }
    end
  end
end
