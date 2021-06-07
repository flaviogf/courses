class User < ApplicationRecord
  EMAIL_REGEX = /\A[^@]+@([^@\.]+\.)+[^@\.]+\z/

  validates_presence_of :full_name, :email, :password, :location

  validates_confirmation_of :password

  validates_length_of :bio, minimum: 30, allow_blank: true

  validate :email_format

  private
  def email_format
    errors.add(:email, :invalid) unless email.match(EMAIL_REGEX)
  end
end
