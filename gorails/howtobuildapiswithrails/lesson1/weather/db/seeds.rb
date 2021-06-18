# This file should contain all the record creation needed to seed the database with its default values.
# The data can then be loaded with the bin/rails db:seed command (or created alongside the database with db:setup).
#
# Examples:
#
#   movies = Movie.create([{ name: 'Star Wars' }, { name: 'Lord of the Rings' }])
#   Character.create(name: 'Luke', movie: movies.first)
l = Location.create(name: 'New York')
l.recordings.create(temp: 32, status: 'cloudy')
l.recordings.create(temp: 37, status: 'cloudy')
l.recordings.create(temp: 35, status: 'cloudy')
l.recordings.create(temp: 22, status: 'sunny')
l.recordings.create(temp: 39, status: 'cloudy')
