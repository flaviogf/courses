exec { "apt_get_update":
  command => "apt-get update",
  path => "/usr/bin"
}

package { ["openjdk-7-jre", "tomcat7"]:
  ensure => "installed",
  require => Exec["apt_get_update"]
}
