class User < ApplicationRecord
  EMAIL_REGEX = /\A[^@]+@([^@\.]+\.)+[^@\.]+\z/

  validates_presence_of :full_name, :email, :location

  validates_length_of :bio, minimum: 30, allow_blank: true

  validate :email_format

  has_secure_password

  private
  def email_format
    errors.add(:email, :invalid) unless email.respond_to?(:match) && email.match(EMAIL_REGEX)
  end
end
