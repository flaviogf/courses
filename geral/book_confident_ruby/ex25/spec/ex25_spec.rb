# frozen_string_literal: true

RSpec.describe Ex25 do
  describe '.list_widgets' do
    it 'returns the expected url' do
      url = described_class.list_widgets

      expected_url = 'http://www.example.com/widgets?page=1&page_size=20'

      expect(url).to eq(expected_url)
    end

    context 'when page size is greater than 20' do
      it 'returns the expected_url' do
        credentials = { user: 'root', password: 'root' }

        url = described_class.list_widgets(credentials: credentials, page_size: 25)

        expected_url = 'https://root:root@www.example.com/widgets?page=1&page_size=25'

        expect(url).to eq(expected_url)
      end

      context 'when credentials is not informed' do
        it 'raises o NoMethodError' do
          expect { described_class.list_widgets(page_size: 25) }.to raise_error(NoMethodError)
        end
      end
    end
  end
end
