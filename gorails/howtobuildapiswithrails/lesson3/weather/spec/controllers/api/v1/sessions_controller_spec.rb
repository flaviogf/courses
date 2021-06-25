# frozen_string_literal: true

require 'rails_helper'

RSpec.describe Api::V1::SessionsController, type: :controller do
  describe 'POST #create' do
    let(:user) { create(:user) }

    context 'when email and password are right' do
      let(:params) { { session: { email: user.email, password: user.password } } }

      before { post :create, params: params }

      it { is_expected.to respond_with(:success) }

      it { expect(response.parsed_body.key?('token')).to be true }
    end

    context 'when email is wrong' do
      let(:params) { { session: { email: 'wrong@email.com', password: user.password } } }

      before { post :create, params: params }

      it { is_expected.to respond_with(:unauthorized) }
    end

    context 'when password is wrong' do
      let(:params) { { session: { email: user.email, password: 'wrong' } } }

      before { post :create, params: params }

      it { is_expected.to respond_with(:unauthorized) }
    end
  end
end
