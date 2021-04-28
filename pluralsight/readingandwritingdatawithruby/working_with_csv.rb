require 'csv'

def main()
    write ["2020-01-04", 4555.00]

    write ["2020-01-05", 15000.00]

    read
end

def write(data)
    CSV.open("prices.csv", "a") do |csv|
        csv << data
    end
end

def read()
    CSV.foreach("prices.csv") do |row|
        puts "Date: #{row[0]}, Price: #{row[1]}"
    end
end

main
