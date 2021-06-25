# frozen_string_literal: true

Rails.application.routes.draw do
  namespace 'api' do
    namespace 'v1' do
      resource :sessions
      resources :locations
    end
  end
end
