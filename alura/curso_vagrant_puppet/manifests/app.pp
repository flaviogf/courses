package { ["apache2", "php", "libapache2-mod-php"]:
  ensure => "installed",
}

file { "/var/www/html/index.php":
  ensure => "link",
  target => "/vagrant/index.php"
}
