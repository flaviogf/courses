# frozen_string_literal: true

require 'net/smtp'
require 'highline/import'

from = 'flaviogf6@outlook.com'

pass = ask 'type your password:' do |q|
  q.echo = '*'
end

to = 'flaviogf6@outlook.com'

msg = <<-MSG
  From: #{from}
  Subject: Testing Ruby SMTP
  Just a test of send an email with Ruby
MSG

smtp = Net::SMTP.new 'smtp.office365.com', 587

begin
  smtp.start 'localhost', from, pass, :plain do |client|
    client.send_message msg, from, to
  end
rescue Net::SMTPAuthenticationError => e
  puts "ERROR: #{e}"
end
