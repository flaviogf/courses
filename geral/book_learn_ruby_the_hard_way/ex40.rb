# frozen_string_literal: true

class Song
  def initialize(lyrics)
    @lyrics = lyrics
  end

  def sing_me_a_song
    @lyrics.each { |line| puts line }
  end
end

happy_birth_day = Song.new(['Happy birthday to you', 'I don\'t want to get sued', 'So I\'ll stop right there'])

happy_birth_day.sing_me_a_song

bulls_on_parade = Song.new(['They rally around tha family', 'With pockets full of shell'])

bulls_on_parade.sing_me_a_song
