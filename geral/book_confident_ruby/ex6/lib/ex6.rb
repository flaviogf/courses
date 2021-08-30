# frozen_string_literal: true

module Ex6
  class Article
    def initialize(title)
      @title = title
    end

    def slug
      @title.strip.tr_s('^A-Za-z0-9', '-').downcase
    end

    def to_str
      @title
    end
  end
end
