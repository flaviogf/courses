require "json"

content = '{"date": "2020-01-01", "price": 5000.00 }'

data = JSON.parse(content)

puts "Date: #{data['date']}, Price: #{data['price']}"

puts JSON.pretty_generate(data)
