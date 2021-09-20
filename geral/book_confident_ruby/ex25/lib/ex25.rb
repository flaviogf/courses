# frozen_string_literal: true

module Ex25
  class << self
    def list_widgets(options = {})
      credentials = options.fetch(:credentials) { :credentials_not_set }
      page_size = options.fetch(:page_size) { 20 }
      page = options.fetch(:page) { 1 }

      return authenticated_url(credentials, page, page_size) if page_size > 20

      anonymous_url(page, page_size)
    end

    def authenticated_url(credentials, page, page_size)
      user = credentials.fetch(:user)
      password = credentials.fetch(:password)

      "https://#{user}:#{password}@www.example.com/widgets?page=#{page}&page_size=#{page_size}"
    end

    def anonymous_url(page, page_size)
      "http://www.example.com/widgets?page=#{page}&page_size=#{page_size}"
    end
  end
end
