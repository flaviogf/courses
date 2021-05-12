class Collection
  def <<(item)
    puts "adding new item, #{item}"
  end
end

class Series < Collection
  def <<(item)
    puts "*** new serie added ***"
    super
  end
end

to_watch = Series.new

to_watch << "The Witcher"
to_watch << "Friends"
to_watch << "Chuck"

