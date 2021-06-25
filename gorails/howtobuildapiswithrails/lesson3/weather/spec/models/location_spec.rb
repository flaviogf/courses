# frozen_string_literal: true

require 'rails_helper'

RSpec.describe Location, type: :model do
  subject { create(:location) }

  it { is_expected.to have_many(:recordings) }

  it { is_expected.to validate_presence_of(:name) }
end
