# frozen_string_literal: true

module Ex5
  class VimConfigFile
    def initialize
      @filename = "#{ENV['HOME']}/.vimrc"
    end

    def to_path
      @filename
    end
  end
end
