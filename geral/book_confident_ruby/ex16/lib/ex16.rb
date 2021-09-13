# frozen_string_literal: true

require 'date'

module Ex16
  class Employee
    attr_reader :name, :hire_date

    def initialize(name, hire_date)
      @name = name
      self.hire_date = hire_date
    end

    def hire_date=(value)
      raise TypeError unless value.is_a?(Date)

      @hire_date = value
    end

    def due_for_tie_pin?
      ((Date.today - hire_date) / 365).to_i >= 10
    end

    def covered_by_pension_plan?
      hire_date.year < 2000
    end

    def bio
      "#{name} has been a Yoyodyne employee since #{hire_date.year}"
    end
  end
end
