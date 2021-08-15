# frozen_string_literal: true

lib = File.expand_path('lib', __dir__)
$LOAD_PATH.unshift(lib) unless $LOAD_PATH.include?(lib)

Gem::Specification.new do |spec|
  spec.name = 'NAME'
  spec.version = '1.0'
  spec.authors = ['Your Name Here']
  spec.email = ['youremail@yourdomain.com']
  spec.summary = 'Short summary of your project'
  spec.description = 'Longer description of your project'
  spec.homepage = 'http://domainforproject.com/'
  spec.license = 'MIT'
  spec.files = ['lib/NAME.rb']
  spec.executables = ['bin/NAME']
  spec.test_files = ['test/test_NAME.rb']
  spec.require_paths = ['lib']
  spec.required_ruby_version = '2.5'
end
