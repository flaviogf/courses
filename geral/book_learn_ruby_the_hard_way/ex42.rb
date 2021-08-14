# frozen_string_literal: true

class Animal; end

class Dog < Animal
  def initialize(name)
    super()
    @name = name
  end
end

class Cat < Animal
  def initialize(name)
    super()
    @name = name
  end
end

class Person
  def initialize(name)
    @name = name
    @pet = nil
  end

  attr_accessor :pet
end

class Employee < Person
  def initialize(name, salary)
    super(name)
    @salary = salary
  end
end

class Fish; end

class Salmon < Fish; end

class Halibut < Fish; end

rover = Dog.new('Rover')

satan = Cat.new('Satan')

mary = Person.new('Mary')

mary.pet = satan

frank = Employee.new('Frank', 120_000)

frank.pet = rover

flipper = Fish.new

crouse = Salmon.new

harry = Halibut.new
