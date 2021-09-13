# frozen_string_literal: true

module Ex16
  RSpec.describe Employee do
    describe '#hire_date' do
      context 'when informed an argument that is a Date' do
        it 'creates a new Employee' do
          employee = Employee.new(Faker::Name.name, Date.today)
          expect(employee).to be_an(Employee)
        end
      end

      context 'when informed an argument that is not a Date' do
        it 'raises a TypeError' do
          expect { Employee.new(Faker::Name.name, 'oops') }.to raise_error(TypeError)
        end
      end
    end
  end
end
