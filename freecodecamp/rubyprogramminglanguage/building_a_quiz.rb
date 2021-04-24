class Question
    attr_accessor :prompt, :answer

    def initialize(prompt, answer)
        @prompt = prompt
        @answer = answer
    end
end

questions = [
    Question.new("What color are apples?\na) blue\nb) yellow\nc) red\n", "c"),
    Question.new("What color are bananas?\na) yellow\nb) orange\nc) pink\n", "a"),
]

def run_test(questions)
    score = 0

    questions.each do |question|
        puts question.prompt
        answer = gets.chomp
        if answer == question.answer
            score += 1
        end
    end

    puts "You got #{score} / #{questions.length}"
end

run_test questions
