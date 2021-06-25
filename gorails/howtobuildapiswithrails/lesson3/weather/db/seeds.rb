# frozen_string_literal: true

# This file should contain all the record creation needed to seed the database with its default values.
# The data can then be loaded with the bin/rails db:seed command (or created alongside the database with db:setup).
#
# Examples:
#
#   movies = Movie.create([{ name: 'Star Wars' }, { name: 'Lord of the Rings' }])
#   Character.create(name: 'Luke', movie: movies.first)

User.create email: 'frank@email.com', password: 'test'

location = Location.create name: 'New York'

location.recordings.create temp: 18, status: 'Cloudy'
location.recordings.create temp: 28, status: 'Sunny'
