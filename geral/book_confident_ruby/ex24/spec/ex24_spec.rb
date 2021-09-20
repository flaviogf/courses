# frozen_string_literal: true

RSpec.describe Ex24 do
  describe '.render_member' do
    let(:member) do
      described_class::Member.new(
        Faker::Name.name,
        Faker::Name.name,
        Faker::Internet.url,
        Faker::Address.city
      )
    end

    let(:group) { described_class::Group.new(location) }

    let(:location) { described_class::Location.new(Faker::Internet.url) }

    let(:geolocatron) { instance_double('geolocatron') }

    before do
      allow(geolocatron).to receive(:locate).and_return(location)
    end

    it 'returns the expected html' do
      expected_html = '<div class="vcard">' \
        "<div class=\"fn\">#{member.fname} #{member.lname}</div>" \
        "<img class=\"photo\" src=\"#{member.avatar_url}\" />" \
        "<img class=\"map\" src=\"#{location.map_url}\" />" \
        '</div>'

      html = described_class.render_member(member, group, geolocatron)

      expect(html).to eq(expected_html)
    end

    context 'when geolocatron returns nothing' do
      before do
        allow(geolocatron).to receive(:locate)
      end

      it 'returns the expected html' do
        expected_html = '<div class="vcard">' \
          "<div class=\"fn\">#{member.fname} #{member.lname}</div>" \
          "<img class=\"photo\" src=\"#{member.avatar_url}\" />" \
          "<img class=\"map\" src=\"#{location.map_url}\" />" \
          '</div>'

        html = described_class.render_member(member, group, geolocatron)

        expect(html).to eq(expected_html)
      end
    end
  end
end
