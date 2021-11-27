require "test_helper"
require "socket"

class ApplicationSystemTestCase < ActionDispatch::SystemTestCase
  driven_by :selenium, using: :chrome, screen_size: [1400, 1400], options: { browser: :remote, url: "http://chrome:4444/wd/hub", capabilities: %i[chrome] }

  def setup
    host! "http://#{IPSocket.getaddress(Socket.gethostname)}"
    super
  end
end
