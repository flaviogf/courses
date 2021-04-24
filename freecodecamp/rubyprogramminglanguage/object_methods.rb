class Student
    attr_accessor :name, :gpa

    def initialize(name, gpa)
        @name = name
        @gpa = gpa
    end

    def has_honor
        @gpa >= 3.5
    end
end

student1 = Student.new("Frank", 3.9)

puts "Does Frank have honor? #{student1.has_honor}"

student2 = Student.new("Peter", 2.8)

puts "Does Peter have honor? #{student2.has_honor}"
