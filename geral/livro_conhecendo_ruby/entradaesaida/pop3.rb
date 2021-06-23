# frozen_string_literal: true

require 'net/pop'
require 'highline/import'

user = 'flaviogf6@outlook.com'

pass = ask 'type your password:' do |q|
  q.echo = '*'
end

pop = Net::POP3.new 'outlook.office365.com', 995
pop.enable_ssl OpenSSL::SSL::VERIFY_NONE

pop.start user, pass do |client|
  if client.mails.empty?
    puts 'Does not have any emails'
  else
    pop.each { |msg| puts msg.header }
  end
end
