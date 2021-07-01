# frozen_string_literal: true

RSpec.shared_examples 'must have' do |klass, attr|
  describe "##{attr}" do
    context 'when is not present' do
      describe '#errors' do
        subject do
          instance = klass.new
          instance.valid?
          instance.errors[attr]
        end

        it { is_expected.to_not be_empty }
      end
    end

    context 'when is present' do
      describe '#errors' do
        subject do
          params = {}
          params[attr] = Faker::Name.name
          instance = klass.new(params)
          instance.valid?
          instance.errors[attr]
        end

        it { is_expected.to be_empty }
      end
    end
  end
end
