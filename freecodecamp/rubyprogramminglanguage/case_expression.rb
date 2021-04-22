def weekdays(abbreviation)
    case abbreviation
    when "mon"
        return "Monday"
    when "tue"
        return "Tuesday"
    when "wed"
        return "Wednesday"
    when "thu"
        return "Thursday"
    when "fri"
        return "Friday"
    when "sat"
        return "Saturday"
    when "sun"
        return "Sunday"
    end
end

puts weekdays("fri")

puts weekdays("tue")
