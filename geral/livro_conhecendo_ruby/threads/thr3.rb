# frozen_string_literal: true

fn = proc do |arg|
  arg.times do |i|
    print "[#{i + 1}/#{arg}]"
    sleep 0.5
  end
end

(1..5).map { |i| Thread.new i, &fn }.each(&:join)
