# frozen_string_literal: true

module Ex27
  RSpec.describe Map do
    subject(:map) { Map.new }

    let(:point) { double('point', :draw_on => nil, :name= => nil) }

    it { is_expected.to respond_to(:draw_point) }

    describe '#draw_on' do
      before { map.draw_point(point) }

      it { expect(point).to have_received(:draw_on).with(map).once }

      context 'when block is given' do
        before { map.draw_point(point) { |it| it.name = 'Main Point' } }

        it { expect(point).to have_received(:name=).with('Main Point').once }
      end
    end
  end
end
