Rails.application.routes.draw do
  resources :cryptocurrency_prices
  resources :cryptocurrencies
  get "/companies", to: "companies#index"
  root "companies#index"
  # For details on the DSL available within this file, see https://guides.rubyonrails.org/routing.html
end
