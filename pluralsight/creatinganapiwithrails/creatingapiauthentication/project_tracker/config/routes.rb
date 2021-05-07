Rails.application.routes.draw do
  post '/user', to: 'user#create'
  post '/session', to: 'session#create'
  get '/project', to: 'project#index'
end
