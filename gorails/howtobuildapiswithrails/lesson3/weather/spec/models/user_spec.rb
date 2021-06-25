# frozen_string_literal: true

require 'rails_helper'

RSpec.describe User, type: :model do
  subject { create(:user) }

  it { is_expected.to have_secure_password }

  it { is_expected.to validate_presence_of(:email) }
end
