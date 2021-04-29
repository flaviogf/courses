require "csv"
require "date"
require "json"
require "net/http"

def main()
    content = fetch

    current_date = content[:current_date]
    
    current_price = content[:current_price]

    store [current_date, current_price]
end

def fetch()
    uri = URI('https://api.coindesk.com/v1/bpi/currentprice.json')

    res = Net::HTTP.get_response(uri)

    body = JSON.parse(res.body)
    
    current_date = Date.parse(body["time"]["updatedISO"]).strftime("%Y-%m-%d")
    
    current_price = body["bpi"]["USD"]["rate_float"]

    return { current_date: current_date, current_price: current_price }
end

def store(row)
    CSV.open("prices.csv", "a") do |csv|
        csv << row
    end
end

main
