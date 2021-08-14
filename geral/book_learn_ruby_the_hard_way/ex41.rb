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

def craft_names(rand_words, snippet, pattern, caps: false)
  names = snippet.scan(pattern).map do
    word = rand_words.pop
    caps ? word.capitalize : word
  end

  names * 2
end

def craft_params(rand_words, snippet, pattern)
  names = (0...snippet.scan(pattern).length).map do
    param_count = rand(1..3)
    params = (0...param_count).map { |_x| rand_words.pop }
    params.join(', ')
  end

  names * 2
end

def convert(snippet, phrase)
  rand_words = WORDS.sort_by { rand }
  class_names = craft_names(rand_words, snippet, /###/, caps: true)
  other_names = craft_names(rand_words, snippet, /\*\*\*/)
  param_names = craft_names(rand_words, snippet, /@@@/)

  results = []

  [snippet, phrase].each do |sentence|
    result = sentence.gsub(/###/) { |_x| class_names.pop }

    result.gsub!(/\*\*\*/) { |_x| other_names.pop }

    result.gsub!(/@@@/) { |_x| param_names.pop }

    results.push(result)
  end

  results
end

loop do
  snippets = PHRASES.keys.sort_by { rand }

  snippets.each do |snippet|
    phrase = PHRASES[snippet]

    question, answer = convert(snippet, phrase)

    question, answer = answer, question if PHRASE_FIRST

    print question, "\n\n>"

    exit(0) unless $stdin.gets

    puts "\nANSWER: %s\n\n" % answer
  end
end
