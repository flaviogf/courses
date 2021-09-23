# frozen_string_literal: true

module Ex28
  class << self
    def delete_files(files, &error_policy)
      error_policy ||= ->(_file, error) { raise error }

      files.each do |file|
        File.delete(file)
      rescue StandardError => e
        error_policy.call(file, e)
      end
    end
  end
end
