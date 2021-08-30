# frozen_string_literal: true

module Ex6
  RSpec.describe Article do
    describe '#slug' do
      context 'when article has title "A Modest Proposal"' do
        subject do
          Article.new('A Modest Proposal').slug
        end

        it { is_expected.to eq('a-modest-proposal') }
      end
    end

    describe '#to_str' do
      context 'when article has title "A Modest Proposal"' do
        subject do
          Article.new('A Modest Proposal').to_str
        end

        it { is_expected.to eq('A Modest Proposal') }
      end
    end
  end
end
