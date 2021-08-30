# frozen_string_literal: true

module Ex7
  class MyFile
    def self.open(filename)
      filename = filename.to_path if filename.respond_to?(:to_path)
      filename = filename.to_str
      filename
    end
  end
end
