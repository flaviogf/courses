class User < ApplicationRecord
  scope :confirmed, -> { where.not(confirmed_at: nil) }

  EMAIL_REGEX = /\A[^@]+@([^@\.]+\.)+[^@\.]+\z/

  validates_presence_of :full_name, :email, :location

  validates_length_of :bio, minimum: 30, allow_blank: true

  validate :email_format

  has_secure_password

  before_create do |user|
    user.confirmation_token = SecureRandom.urlsafe_base64
  end

  def self.authenticate(email, password)
    confirmed.find_by(email: email)&.authenticate(password)
  end

  def confirm!
    return if confirmed?

    self.confirmed_at = Time.current

    self.confirmation_token = ''

    save!
  end

  def confirmed?
    confirmed_at.present?
  end

  private
  def email_format
    errors.add(:email, :invalid) unless email.respond_to?(:match) && email.match(EMAIL_REGEX)
  end
end
