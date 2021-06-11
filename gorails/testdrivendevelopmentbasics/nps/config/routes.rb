Rails.application.routes.draw do
  devise_for :users
  resources :ratings
  resources :people
  resources :projects

  root to: 'home#index'
end
