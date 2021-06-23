# frozen_string_literal: true

require 'net/smtp'
require 'highline/import'

from = 'flaviogf6@outlook.com'

pass = ask 'type your password:' do |q|
  q.echo = '*'
end

to = 'flaviogf6@outlook.com'

msg = <<~MSG
  From: #{from}
  Subject: Testing Ruby SMTP

  Just a test of send an email with Ruby
MSG

Net::SMTP.start 'smtp.office365.com', 587, 'localhost', from, pass, :login do |smtp|
  smtp.send_message msg, from, to
end
