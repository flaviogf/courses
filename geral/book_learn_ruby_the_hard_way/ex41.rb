# frozen_string_literal: true

require 'net/http'

WORD_URL = 'https://learncodethehardway.org/words.txt'
WORDS = []

PHRASES = {
  "class ### < ###\nend" => 'Make a class named ### that is-a ###',
  "class ###\n\tdef initialize(@@@)\n\tend\nend" => 'class ### has-a initialize that takes @@@ parameters.',
  "class ###\n\tdef ***(@@@)\n\tend\nend" => 'class ### has-a function named *** that takes @@@ parameters.',
  '*** = ###.new()' => 'Set *** to an instance of class ###.',
  '***.***(@@@)' => 'From *** get the *** function, and call it with parameters @@@.',
  '***.*** = \'***\'' => 'From *** get the *** attribute and set it to \'***\'.'
}

PHRASE_FIRST = ARGV[0] == 'english'

Net::HTTP.get_response(URI(WORD_URL)) do |resp|
  resp.read_body do |words|
    WORDS.concat(words.split)
  end
end
