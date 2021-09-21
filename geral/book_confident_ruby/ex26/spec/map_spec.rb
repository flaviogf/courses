# frozen_string_literal: true

module Ex26
  RSpec.describe Map do
    subject(:map) { Map.new }

    let(:x) { double('x', draw_on: nil) }

    let(:y) { double('y', draw_on: nil) }

    it { is_expected.to respond_to(:draw_point) }

    describe '#draw_point' do
      before { map.draw_point(x) }

      it { expect(x).to have_received(:draw_on).with(map).once }
    end

    describe '#draw_line' do
      before { map.draw_line(x, y) }

      it { expect(x).to have_received(:draw_on).with(map).once }

      it { expect(y).to have_received(:draw_on).with(map).once }
    end
  end
end
