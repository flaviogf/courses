# frozen_string_literal: true

require 'rails_helper'

RSpec.describe Pokemon, type: :model do
  include_examples 'must have', Pokemon, :name

  it { is_expected.to check_presence_of(:name) }

  describe '.chose_yesterday' do
    before do
      Timecop.freeze(Time.zone.local(2014, 3, 7, 12))
    end

    after do
      Timecop.return
    end

    let!(:pokemon_chose_today) do
      create(:pokemon, chose_at: Time.zone.local(2014, 3, 7, 15))
    end

    let!(:pokemon_chose_yesterday) do
      create(:pokemon, chose_at: Time.zone.local(2014, 3, 6, 23, 59, 59))
    end

    let!(:pokemon_chose_two_days_ago) do
      create(:pokemon, chose_at: Time.zone.local(2014, 3, 5))
    end

    subject do
      Pokemon.chose_yesterday
    end

    it { is_expected.to include(pokemon_chose_yesterday) }

    it { is_expected.to_not include(pokemon_chose_today) }

    it { is_expected.to_not include(pokemon_chose_two_days_ago) }
  end

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
