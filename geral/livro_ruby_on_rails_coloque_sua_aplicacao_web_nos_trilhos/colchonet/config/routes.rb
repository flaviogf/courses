Rails.application.routes.draw do
  root 'home#index'

  resources :rooms
  resources :users
end
