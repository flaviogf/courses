class SQL
  def from(table)
    @table = table
    self
  end

  def where(cond)
    @cond = cond
    self
  end

  def order(order)
    @order = order
    self
  end
  
  def to_s
    "select * from #{@table} where #{@cond} order by #{@order}"
  end
end

puts SQL.new.from("carros").where("marca='Ford'").order("modelo")
