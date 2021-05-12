class User
  attr_reader :id

  def initialize(id:)
    @id = id
  end

  def is_authorized?
    db_role && db_plan
  end

  def db_role
    false
  end

  def db_plan
    true
  end

  def ==(other)
    @id == other.id
  end

  private :db_role, :db_plan

  protected :id
end


user1 = User.new id: 1

user2 = User.new id: 2

puts user1.is_authorized?

# puts user1.db_role 💣

puts user1.__send__(:db_role)

puts user1.__send__(:db_plan)

# puts user1.id 💣

puts user1 == user2
