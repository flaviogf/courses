RSpec.describe 'WelcomeViews' do
  it 'shows the number of views' do
    visit '/'
    expect(page.text).to match(/This page has been viewed [0-9]+ times?/)
  end
end
