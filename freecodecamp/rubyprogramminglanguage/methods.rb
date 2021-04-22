def sum(invoices)
    invoices.map{|x| x[:amount]}.sum
end

invoices = [
    {:amount => 100},
    {:amount => 1000},
    {:amount => 10000}
]

puts sum(invoices)
