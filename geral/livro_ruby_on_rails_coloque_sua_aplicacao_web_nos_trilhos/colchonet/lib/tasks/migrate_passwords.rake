namespace :app do
  desc 'Encrypt all passwords that were not migrated'

  task migrate_passwords: :environment do
    unless User.attribute_names.include? 'password'
      puts 'All passwords were already migrated'
      return
    end

    User.find_each do |user|
      puts "Migrating user #{user.id} #{user.full_name}"
      user.password = user.attributes['password']
      user.password_confirmation = user.attributes['password']
      user.save!
    end
  end
end
