# frozen_string_literal: true

module Ex26
  RSpec.describe Map do
    subject(:map) { Map.new }

    let(:point) { double('point', draw_on: nil) }

    it { is_expected.to respond_to(:draw_point) }

    describe '#draw_point' do
      before { map.draw_point(point) }

      it { expect(point).to have_received(:draw_on).with(map).once }
    end
  end
end
