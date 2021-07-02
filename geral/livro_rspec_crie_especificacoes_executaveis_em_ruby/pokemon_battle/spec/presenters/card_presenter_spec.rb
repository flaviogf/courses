# frozen_string_literal: true

require 'rails_helper'

RSpec.describe CardPresenter do
  describe '#show' do
    let(:object) do
      double('some object', to_presenter: { name: 'Frank', age: 24 })
    end

    subject do
      CardPresenter.new(object).show
    end

    it { is_expected.to eq('<p>name: Frank</p><p>age: 24</p>') }
  end
end
