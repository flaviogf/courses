# frozen_string_literal: true

module Ex15
  class BenchmarkedLogger
    class IrcBot
      def initialize(bot)
        @bot = bot
      end

      def <<(message)
        @bot.dispatch(message)
      end
    end

    def initialize(sink = $stdout)
      @sink = case sink
              when Bot then IrcBot.new(sink)
              else sink
              end
    end

    def info(message)
      start_time = Time.now
      yield
      duration = Time.now - start_time
      line = format("[%<duration>1.2f] %<message>s\n", duration: duration, message: message)
      @sink << line
    end
  end

  class Bot
    def initialize(stream = $stdout)
      @stream = stream
    end

    def dispatch(message)
      @stream << "BOT: #{message}"
    end
  end
end
