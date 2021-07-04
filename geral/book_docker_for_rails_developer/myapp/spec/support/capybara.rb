Capybara.register_driver :selenium_chrome_in_container do |app|
  Capybara::Selenium::Driver.new app,
                                 browser: :remote,
                                 url: 'http://selenium:4444/wd/hub',
                                 desired_capabilities: :chrome
end
