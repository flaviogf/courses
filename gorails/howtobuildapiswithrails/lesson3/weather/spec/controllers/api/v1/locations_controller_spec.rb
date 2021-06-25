# frozen_string_literal: true

require 'rails_helper'

RSpec.describe Api::V1::LocationsController, type: :controller do
  describe 'GET #index' do
    context 'when is not authenticated' do
      before { get :index }

      it { is_expected.to respond_with(:unauthorized) }
    end

    context 'when is authenticated' do
      before { 2.times { create(:location) } }

      before { sign_in(create(:user)) }

      before { get :index }

      it { is_expected.to respond_with(:success) }

      it { expect(response.parsed_body).to be_an Array }

      it { expect(response.parsed_body.count).to eq 2 }

      it { expect(response.parsed_body.first.key?('id')).to be true }

      it { expect(response.parsed_body.first.key?('name')).to be true }
    end
  end
end
