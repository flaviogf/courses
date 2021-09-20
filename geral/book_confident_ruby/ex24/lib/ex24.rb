# frozen_string_literal: true

module Ex24
  Member = Struct.new(:fname, :lname, :avatar_url, :address)

  Location = Struct.new(:map_url)

  Group = Struct.new(:city_location)

  class << self
    def render_member(member, group, geolocatron)
      location = geolocatron.locate(member.address) || group.city_location

      '<div class="vcard">' \
      "<div class=\"fn\">#{member.fname} #{member.lname}</div>" \
      "<img class=\"photo\" src=\"#{member.avatar_url}\" />" \
      "<img class=\"map\" src=\"#{location.map_url}\" />" \
      '</div>'
    end
  end
end
