json.data do |json|
  json.array! @projects do |project|
    json.id project.id
    json.title project.title
    json.user project.user, partial: 'user/user', as: :user
  end
end
