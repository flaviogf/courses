secret_number = 42
guess = 0
guess_count = 0
guess_limit = 3
out_of_guesses = false

while guess != secret_number and not out_of_guesses
    if guess_count < guess_limit
        print "Enter your guess: "
        guess = gets.chomp.to_i
        guess_count += 1
    else
        out_of_guesses = true
    end
end

if not out_of_guesses
    puts "Congratulations, you won the game 🎇"
    
    puts "You took #{guess_count} guesses to found out the secret number"
else
    puts "Sorry, you loose the game try again"
end
