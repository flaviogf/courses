# frozen_string_literal: true

require 'net/ftp'

host = 'ftp.mozila.org'
user = 'anonymous'
pass = 'flavio.fernandes6@gmail.com'
file = 'README'

begin
  Net::FTP.open host do |ftp|
    ftp.login user, pass

    ftp.chdir 'pub'

    ftp.get file

    puts File.read(file)
  end
rescue RuntimeError => e
  puts "ERROR: #{e}"
end
