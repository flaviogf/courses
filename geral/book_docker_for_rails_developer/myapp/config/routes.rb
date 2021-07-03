Rails.application.routes.draw do
  resources :users
  root to: 'welcome#index'
end
