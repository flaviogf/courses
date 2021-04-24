class Chef
    def make_salad
        puts "Chef made a salad"
    end
end

class ItalianChef < Chef
end

chef = ItalianChef.new

chef.make_salad

